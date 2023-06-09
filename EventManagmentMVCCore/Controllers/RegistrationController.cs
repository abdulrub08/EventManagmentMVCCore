using Microsoft.AspNetCore.Mvc;
using Event.DAL;
using Event.DAL.Repository;
using Event.DOM;
using System.Web.Helpers;
using Event.DAL.Repositories;
using EventManagmentMVCCore.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EventManagmentMVCCore.Security;

namespace EventManagmentMVCCore.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        IRegistrationRepository _registrationRepository;
        IDropdownCommonRepository _dropdownCommonRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public RegistrationController(ILogger<HomeController> logger,
            IRegistrationRepository registrationRepository,IDropdownCommonRepository dropdownCommonRepository,
            IConfiguration configuration)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
            _configuration = configuration;
            _dropdownCommonRepository = dropdownCommonRepository;
        }

        public ActionResult Registration()
        {
            try
            {
                AddCookie_For_API_Validation(4); //Anonymous 
                List<SelectListItem> _countrylist = _dropdownCommonRepository.GetCountry()
               .Select(x =>
               new SelectListItem
               {
                   Value = Convert.ToString(x.CountryID),
                   Text = x.Name
               }).ToList();
                var selectListItem = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select country ---"
                };
                _countrylist.Insert(0, selectListItem);
                TempData["country"] = _countrylist;
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(Registration registration)
        {
            try
            {
                if (registration != null)
                {
                    registration.Password= EncryptionLibrary.EncryptText(registration.Password);
                    registration.ConfirmPassword= EncryptionLibrary.EncryptText(registration.ConfirmPassword);
                    var result = _registrationRepository.NEW_Customer(registration);
                    return RedirectToAction("Login", "Login");
                }
                TempData.Keep("country");
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        [HttpPost]
        public JsonResult GetState(int Id)
        {
            List<SelectListItem> _statelist = _dropdownCommonRepository.GetStatebyID(Id)
               .Select(n =>
               new SelectListItem
               {
                   Value = Convert.ToString(n.StateID),
                   Text = n.StateName
               }).ToList();
            var selectListItem = new SelectListItem()
            {
                Value = null,
                Text = "--- select state ---"
            };
            _statelist.Insert(0, selectListItem);
            return Json(_statelist);
        }
        [HttpPost]
        public JsonResult GetCity(int Id)
        {
            List<SelectListItem> _citylist = _dropdownCommonRepository.GetCitybyID(Id)
               .Select(n =>
               new SelectListItem
               {
                   Value = Convert.ToString(n.CityID),
                   Text = n.CityName
               }).ToList();
            var selectListItem = new SelectListItem()
            {
                Value = null,
                Text = "--- select city ---"
            };
            _citylist.Insert(0, selectListItem);
            return Json(_citylist);
        }
        [NonAction]
        public void AddCookie_For_API_Validation(int ID)
        {
            try
            {
                AntiForgeryValidate antiForgeryValidate = new AntiForgeryValidate(_configuration);
                string cookieToken= antiForgeryValidate.GenerateJSONWebToken();
                string formToken = cookieToken;
                //AntiForgery.GetTokens(null, out cookieToken, out formToken);
                ViewBag.cookieToken = cookieToken;
                ViewBag.formToken = formToken;
                Random rm = new Random();
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                options.Secure = true;
                options.HttpOnly = true;
                string value= ID + "*" + cookieToken + "*" + formToken + "*" + DateTime.Now.Date.ToShortDateString() + "*" + DateTime.Now.Date.ToShortTimeString();
                Response.Cookies.Append("EventChannel", value, options);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
