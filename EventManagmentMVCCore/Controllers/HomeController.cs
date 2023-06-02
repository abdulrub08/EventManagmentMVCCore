using Event.DAL.Repositories;
using Event.DOM;
using EventManagmentMVCCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventManagmentMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccount _accountService;

        public HomeController(ILogger<HomeController> logger,
            IAccount accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
           Registration registration = _accountService.GetLogedinUserByUserIDPassword("Admin", "123456");
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}