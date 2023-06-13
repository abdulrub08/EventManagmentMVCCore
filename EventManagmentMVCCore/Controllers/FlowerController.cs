using Event.DAL.Repositories;
using Event.DOM;
using EventManagmentMVCCore.Services;
using EventManagmentMVCCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagmentMVCCore.Controllers
{
    public class FlowerController : Controller
    {
        private readonly ILogger<FlowerController> _logger;
        private readonly ICommonRepository _equipmentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFileUploadServices fileUploadServices;
        public FlowerController(ILogger<FlowerController> logger,
            IWebHostEnvironment hostingEnvironment, ICommonRepository equipmentRepository,
            IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            _equipmentRepository = equipmentRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.fileUploadServices = fileUploadServices;
        }

        // GET: FlowerController
        public async Task<IActionResult> Index()
        {
            var result = await Task.FromResult(_equipmentRepository.GetAll<Flower>($"Select * from [Flower]", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: FlowerController/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            var result = await Task.FromResult(_equipmentRepository.Get<Flower>($"Select * from [Flower] where FlowerID = {Id}", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: FlowerController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: FlowerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlowerViewModel data)
        {
            if (ModelState.IsValid)
            {

                if (data.Photo != null)
                {
                    data.FlowerFilePath = await fileUploadServices.Upload(data.Photo);
                    data.FlowerFilename = data.Photo.FileName;
                }
                Flower newval = new Flower
                {
                    FlowerFilename = data.FlowerFilename,
                    FlowerName = data.FlowerName,
                    FlowerCost = data.FlowerCost,
                    FlowerFilePath = data.FlowerFilePath,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                    Createdate = DateTime.Now
                };
                var result = await Task.FromResult(_equipmentRepository.Insert<Flower>("[dbo].[FlowerInsert]", newval,
               commandType: CommandType.StoredProcedure));
                return RedirectToAction(nameof(Details), new { id = result.FlowerID });
            }
            return View();
        }

        // GET: FlowerController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            Flower result = await Task.FromResult(_equipmentRepository.Get<Flower>($"Select * from [Flower] where FlowerID = {Id}", null, commandType: CommandType.Text));
            FlowerViewModel equipmentEditViewModel = new FlowerViewModel
            {
                FlowerID = result.FlowerID,
                FlowerName = result.FlowerName,
                FlowerCost = result.FlowerCost,
                FlowerFilename = result.FlowerFilename,
                FlowerFilePath = result.FlowerFilePath,
                Createdby = result.Createdby,
                Createdate = result.Createdate
            };
            return View(equipmentEditViewModel);
        }

        // POST: FlowerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FlowerViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (data.Photo != null)
                    {
                        data.FlowerFilePath = await fileUploadServices.Upload(data.Photo);
                        data.FlowerFilename = data.Photo.FileName;
                    }
                    Flower newVenvue = new Flower
                    {
                        FlowerID = data.FlowerID,
                        FlowerName = data.FlowerName,
                        FlowerCost = data.FlowerCost,
                        FlowerFilename = data.FlowerFilename,
                        FlowerFilePath = data.FlowerFilePath,
                        Createdby = data.Createdby,
                        Createdate = data.Createdate
                    };
                    var result = await Task.FromResult(_equipmentRepository.Update<Flower>("[dbo].[FlowerUpdate]"
                   , newVenvue,
                   commandType: CommandType.StoredProcedure));
                    return RedirectToAction(nameof(Details), new { id = result.FlowerID });
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: FlowerController/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            Flower result = await Task.FromResult(_equipmentRepository.Get<Flower>($"Select * from [Flower] where FlowerID = {Id}", null, commandType: CommandType.Text));
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: FlowerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Light model)
        {
            try
            {
                if (_equipmentRepository.Delete<Flower>($"Delete from Flower where FlowerID = {id}", null, CommandType.Text) > 0)
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

    }
}
