using Health_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            loginModel model = new loginModel();
            
            if (ControllerContext.HttpContext.Session["Username"] == null && ControllerContext.HttpContext.Session["Password"] == null)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
               return View();
        }

        public ActionResult Profile()
        {
            return View("~/Views/Shared/_userProfile.cshtml");
        }
    }
}