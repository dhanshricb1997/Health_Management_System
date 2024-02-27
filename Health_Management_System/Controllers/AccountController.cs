using Health_Management_System.Models;
using Health_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Health_Management_System.Models;
using System.Data;
using Health_Management_System.Repository;

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
           
            
                Registation obj1 = new Registation();
                //DAC abc = new DAC();
                DataTable dt = new DataTable();

                dt = _dac.dropDown();
                List<SelectListItem> roleoptions = dt.AsEnumerable().Select(row => new SelectListItem
                {
                    Value = row["DocId"].ToString(),
                    Text = row["Role"].ToString()
                }).ToList();

                var model = new Registation
                {
                   roleList = roleoptions
                };
                //return View(model.role);
            
            return Json(model.role, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDropdownOptions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registation model)
        {
            if(ModelState.IsValid)
            {
            return View("registartionForm", model);

            }
            else
            {
                return View();
            }
            
        }
    }
}