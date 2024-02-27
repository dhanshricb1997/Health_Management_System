using Health_Management_System.Models;
using Health_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Health_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DAC _dac;
        public DashboardController()
        {
            string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            // Pass your connection string to the Dac constructor
            _dac = new DAC(con);
        }
        // GET: Dashboard
        public ActionResult Index(int? page)
        {
            return View();
        }
        public ActionResult Dashboard(int? page, string searchTerm)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 1; // Adjust the page size as needed
            loginModel model = new loginModel();
            List<Registation> details = new List<Registation>();
            if (searchTerm != null)
            {
                details = _dac.getAllDetails(searchTerm);
                ViewBag.SearchTerm = searchTerm;
            }
            else
                details = _dac.getAllDetails(searchTerm);

            IPagedList<Registation> pagedData = details.ToPagedList(pageNumber, pageSize);
            if (ControllerContext.HttpContext.Session["Username"] == null && ControllerContext.HttpContext.Session["Password"] == null)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
               return View(pagedData);
        }

        public ActionResult Profile()
        {
            return View("~/Views/Shared/_userProfile.cshtml");
        }
    }
}