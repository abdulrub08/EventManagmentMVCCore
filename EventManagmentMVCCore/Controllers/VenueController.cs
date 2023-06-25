﻿using Event.DAL.Repositories;
using Event.DAL.Repository;
using Event.DOM;
using EventManagmentMVCCore.Services;
using EventManagmentMVCCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;

namespace EventManagmentMVCCore.Controllers
{
    public class VenueController : Controller
    {
        private readonly ILogger<VenueController> _logger;
        private readonly IVenueRepository _venueRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IFileUploadServices fileUploadServices;
        public VenueController(ILogger<VenueController> logger, IWebHostEnvironment hostingEnvironment, 
            IVenueRepository venueRepository, 
            IFileUploadServices fileUploadServices)
        {
            _logger = logger;
            _venueRepository = venueRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.fileUploadServices = fileUploadServices;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VenueViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (model.Photo != null)
                {
                  model.VenueFilePath = await fileUploadServices.Upload(model.Photo);
                  model.VenueFilename= model.Photo.FileName;
                }
                Venue newVenvue = new Venue
                {
                    VenueFilename= model.VenueFilename,
                    VenueName=model.VenueName,
                    VenueCost=model.VenueCost,
                    VenueFilePath=model.VenueFilePath,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };
                var createdVenue = await _venueRepository.SaveVenueAsync(newVenvue);
                return RedirectToAction("VenueDetails", new { id = createdVenue.VenueID });
            }
            return View();
        }
        public IActionResult VenueShowall()
        {
            IEnumerable<Venue> venues = _venueRepository.ShowVenue();
            return View(venues);
        }
        public IActionResult VenueEdit(int id)
        {
            Venue venue = _venueRepository.VenueByID(id);
            VenueEditViewModel venueEditView = new VenueEditViewModel()
            {
                Id = venue.VenueID,
                ExistingPhotoPath=venue.VenueFilePath,
                VenueCost=venue.VenueCost,
                VenueFilename=venue.VenueFilename,
                VenueFilePath = venue.VenueFilePath,
                VenueName = venue.VenueName
            };
            return View(venueEditView);
        }
        [HttpPost]
        public IActionResult VenueEdit(VenueEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    model.VenueFilePath = uniqueFileName;
                    model.VenueFilename = model.Photo.FileName;
                }

                Venue newVenvue = new Venue
                {
                    VenueFilename = model.VenueFilename,
                    VenueName = model.VenueName,
                    VenueCost = model.VenueCost,
                    VenueFilePath = model.VenueFilePath,
                    Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID"))
                };
                var createdVenue =  _venueRepository.UpdateVenue(newVenvue);
                //return RedirectToAction("VenueDetails", new { id = createdVenue.VenueID });
            }
            return View(model);
        }
        public IActionResult VenueDetails(int id)
        {
            Venue venue = _venueRepository.VenueByID(id);
            return View(venue);
        }
    }
}
