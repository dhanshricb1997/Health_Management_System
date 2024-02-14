using Health_Management_System.Models;
using Health_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly DAC _dac;
        public AccountController()
        {
            string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            // Pass your connection string to the Dac constructor
            _dac = new DAC(con);
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            
            
           
            if (ModelState.IsValid)
            {

                loginModel loginData = _dac.userlogin(model);
                ControllerContext.HttpContext.Session["Username"] = loginData.Username;
                ControllerContext.HttpContext.Session["Password"] = loginData.Password;
                if (loginData.Username == model.Username && loginData.Password == model.Password)
                {
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "" });
                }
                
            }
                            
            return View("Login", model);
            
        }
        public ActionResult registartionForm()
        {
            return View();
        }
    }
}