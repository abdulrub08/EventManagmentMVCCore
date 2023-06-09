using Dapper;
using Event.DAL.Repository;
using EventManagmentMVCCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using EventManagmentMVCCore.ViewModel;
using Event.DOM;
using Event.DAL.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventManagmentMVCCore.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ILogger<EquipmentController> _logger;
        private readonly CommonRepository _equipmentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFileUploadServices fileUploadServices;
        public EquipmentController(ILogger<EquipmentController> logger, 
            IWebHostEnvironment hostingEnvironment, CommonRepository equipmentRepository, 
            IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            _equipmentRepository = equipmentRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.fileUploadServices = fileUploadServices;
        }
        // GET: HomeController1
        public async Task<IActionResult> Index()
        {
            var result = await Task.FromResult(_equipmentRepository.GetAll<Equipment>($"Select * from [Equipment]", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: HomeController1/Details/5s
        public async Task<IActionResult> Details(int Id)
        {
            var result = await Task.FromResult(_equipmentRepository.Get<Equipment>($"Select * from [Equipment] where EquipmentID = {Id}", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentViewModel data)
        {
            if (ModelState.IsValid)
            {

                if (data.Photo != null)
                {
                    data.EquipmentFilePath = await fileUploadServices.Upload(data.Photo);
                    data.EquipmentFilename = data.Photo.FileName;
                }
                Equipment newVenvue = new Equipment
                {
                    EquipmentFilename = data.EquipmentFilename,
                    EquipmentName = data.EquipmentName,
                    EquipmentCost = data.EquipmentCost,
                    EquipmentFilePath = data.EquipmentFilePath,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                    Createdate=DateTime.Now
                };
                var result = await Task.FromResult(_equipmentRepository.Insert<Equipment>("[dbo].[EquipmentInsert]"
               , newVenvue,
               commandType: CommandType.StoredProcedure));
                return RedirectToAction(nameof(Details), new { id = result.EquipmentID });
            }
            return View();
        }

        // GET: HomeController1/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            Equipment result = await Task.FromResult(_equipmentRepository.Get<Equipment>($"Select * from [Equipment] where EquipmentID = {Id}", null, commandType: CommandType.Text));
            EquipmentViewModel equipmentEditViewModel = new EquipmentViewModel
            {
                EquipmentID = result.EquipmentID,
                EquipmentName = result.EquipmentName,
                EquipmentCost = result.EquipmentCost,
                EquipmentFilename = result.EquipmentFilename,
                EquipmentFilePath = result.EquipmentFilePath,
                Createdby = result.Createdby,
                Createdate = result.Createdate
            };
            return View(equipmentEditViewModel);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EquipmentViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (data.Photo != null)
                    {
                        data.EquipmentFilePath = await fileUploadServices.Upload(data.Photo);
                        data.EquipmentFilename = data.Photo.FileName;
                    }
                    Equipment newVenvue = new Equipment
                    {
                        EquipmentID = data.EquipmentID,
                        EquipmentFilePath = data.EquipmentFilePath,
                        EquipmentFilename = data.EquipmentFilename,
                        EquipmentName = data.EquipmentName,
                        EquipmentCost = data.EquipmentCost,
                        Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                        Createdate = DateTime.Now
                    };
                    var result = await Task.FromResult(_equipmentRepository.Update<Equipment>("[dbo].[EquipmentUpdate]"
                   , newVenvue,
                   commandType: CommandType.StoredProcedure));
                    return RedirectToAction(nameof(Details), new { id = result.EquipmentID });
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: HomeController1/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            Equipment result = await Task.FromResult(_equipmentRepository.Get<Equipment>($"Select * from [Equipment] where EquipmentID = {Id}", null, commandType: CommandType.Text));
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Equipment model)
        {
            try
            {
                if (_equipmentRepository.Delete<Equipment>($"Delete from Equipment where EquipmentID = {id}", null,CommandType.Text) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }


        #region for Future Use
        //[HttpGet(nameof(Count))]
        //public Task<int> Count(int num)
        //{
        //    var totalcount = Task.FromResult(_equipmentRepository.Get<int>($"select COUNT(*) from [Equipment] WHERE Age like '%{num}%'", null,
        //            commandType: CommandType.Text));
        //    return totalcount;
        //}
        //[HttpPatch(nameof(Update))]
        //public Task<int> Update(Equipment data)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("Id", data.EquipmentID);
        //    dbPara.Add("Name", data.EquipmentName, DbType.String);

        //    var updateArticle = Task.FromResult(_equipmentRepository.Update<int>("[dbo].[SP_Update_Article]",
        //                    dbPara,
        //                    commandType: CommandType.StoredProcedure));
        //    return updateArticle;
        //}

        #endregion
    }
}
