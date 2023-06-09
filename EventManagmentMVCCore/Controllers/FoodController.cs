using Event.DAL.Repositories;
using Event.DAL.Repository;
using Event.DOM;
using EventManagmentMVCCore.Services;
using EventManagmentMVCCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagmentMVCCore.Controllers
{
    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;
        private readonly ICommonRepository _commonRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFileUploadServices fileUploadServices;
        public FoodController(ILogger<FoodController> logger,
            IWebHostEnvironment hostingEnvironment, ICommonRepository commonRepository,
            IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            _commonRepository = commonRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.fileUploadServices = fileUploadServices;
        }
        // GET: FoodController
        public async Task<IActionResult> Index()
        {
            var result = await Task.FromResult(_commonRepository.GetAll<Food>($"Select * from [Food]", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: FoodController/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            var result = await Task.FromResult(_commonRepository.Get<Food>($"Select * from [Food] where FoodID = {Id}", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodViewModel data)
        {
            if (ModelState.IsValid)
            {

                if (data.Photo != null)
                {
                    data.FoodFilePath = await fileUploadServices.Upload(data.Photo);
                    data.FoodFilename = data.Photo.FileName;
                }
                Food newFood = new Food
                {
                    FoodFilename = data.FoodFilename,
                    FoodName = data.FoodName,
                    FoodCost = data.FoodCost,
                    FoodType = data.FoodType,
                    DishType = data.DishType,
                    MealType = data.MealType,
                    FoodFilePath = data.FoodFilePath,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                    Createdate = DateTime.Now
                };
                var result = await Task.FromResult(_commonRepository.Insert<Food>("[dbo].[EquipmentInsert]"
               , newFood,
               commandType: CommandType.StoredProcedure));
                return RedirectToAction(nameof(Details), new { id = result.FoodID });
            }
            return View();
        }

        // GET: FoodController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            Food data = await Task.FromResult(_commonRepository.Get<Food>($"Select * from [Equipment] where EquipmentID = {Id}", null, commandType: CommandType.Text));
            FoodViewModel equipmentEditViewModel = new FoodViewModel
            {
                FoodFilename = data.FoodFilename,
                FoodName = data.FoodName,
                FoodCost = data.FoodCost,
                FoodType = data.FoodType,
                DishType = data.DishType,
                MealType = data.MealType,
                FoodFilePath = data.FoodFilePath,
                Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                Createdate = DateTime.Now
            };
            return View(equipmentEditViewModel);
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
