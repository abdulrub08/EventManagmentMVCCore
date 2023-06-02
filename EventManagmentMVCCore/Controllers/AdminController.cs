using EventManagmentMVCCore.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagmentMVCCore.Controllers
{
    [AdminUser("1")]
    public class AdminController : Controller
    {     
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
