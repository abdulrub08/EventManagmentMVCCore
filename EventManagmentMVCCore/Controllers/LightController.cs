using Event.DAL.Repositories;
using Event.DOM;
using EventManagmentMVCCore.Services;
using EventManagmentMVCCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagmentMVCCore.Controllers
{
    public class LightController : Controller
    {
        private readonly ILogger<LightController> _logger;
        private readonly ICommonRepository _equipmentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFileUploadServices fileUploadServices;
        public LightController(ILogger<LightController> logger,
            IWebHostEnvironment hostingEnvironment, ICommonRepository equipmentRepository,
            IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            _equipmentRepository = equipmentRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.fileUploadServices = fileUploadServices;
        }
        // GET: LightController
        public async Task<IActionResult> Index()
        {
            var result = await Task.FromResult(_equipmentRepository.GetAll<Light>($"Select * from [Light]", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: LightController/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            var result = await Task.FromResult(_equipmentRepository.Get<Light>($"Select * from [Light] where LightID = {Id}", null, commandType: CommandType.Text));
            return View(result);
        }

        // GET: LightController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: LightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LightViewModel data)
        {
            if (ModelState.IsValid)
            {

                if (data.Photo != null)
                {
                    data.LightFilePath = await fileUploadServices.Upload(data.Photo);
                    data.LightFilename = data.Photo.FileName;
                }
                Light newval = new Light
                {
                    LightFilename = data.LightFilename,
                    LightName = data.LightName,
                    LightCost = data.LightCost,
                    LightFilePath = data.LightFilePath,
                    LightType = data.LightType,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                    Createdate = DateTime.Now
                };
                var result = await Task.FromResult(_equipmentRepository.Insert<Light>("[dbo].[EquipmentInsert]", newval,
               commandType: CommandType.StoredProcedure));
                return RedirectToAction(nameof(Details), new { id = result.LightID });
            }
            return View();
        }

        // GET: LightController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            Light result = await Task.FromResult(_equipmentRepository.Get<Light>($"Select * from [Light] where LightID = {Id}", null, commandType: CommandType.Text));
            LightViewModel equipmentEditViewModel = new LightViewModel
            {
                LightID = result.LightID,
                LightName = result.LightName,
                LightCost = result.LightCost,
                LightFilename = result.LightFilename,
                LightFilePath = result.LightFilePath,
                LightType=result.LightType,
                Createdby = result.Createdby,
                Createdate = result.Createdate
            };
            return View(equipmentEditViewModel);
        }

        // POST: LightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LightViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (data.Photo != null)
                    {
                        data.LightFilePath = await fileUploadServices.Upload(data.Photo);
                        data.LightFilename = data.Photo.FileName;
                    }
                    Light newVenvue = new Light
                    {
                        LightID = data.LightID,
                        LightName = data.LightName,
                        LightCost = data.LightCost,
                        LightFilename = data.LightFilename,
                        LightFilePath = data.LightFilePath,
                        LightType = data.LightType,
                        Createdby = data.Createdby,
                        Createdate = data.Createdate
                    };
                    var result = await Task.FromResult(_equipmentRepository.Update<Light>("[dbo].[EquipmentUpdate]"
                   , newVenvue,
                   commandType: CommandType.StoredProcedure));
                    return RedirectToAction(nameof(Details), new { id = result.LightID });
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: LightController/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            Light result = await Task.FromResult(_equipmentRepository.Get<Light>($"Select * from [Light] where LightID = {Id}", null, commandType: CommandType.Text));
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: LightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Light model)
        {
            try
            {
                if (_equipmentRepository.Delete<Equipment>($"Delete from Light where LightID = {id}", null, CommandType.Text) > 0)
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
