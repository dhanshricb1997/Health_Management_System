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
                string pass = "";
                loginModel loginData = _dac.userlogin(model);
                string abc = loginData.Id.ToString();
                if (!string.IsNullOrEmpty(loginData.Password))
                {
                    pass = loginData.Password.ToString();
                }

                if (!string.IsNullOrEmpty(abc) && !string.IsNullOrEmpty(pass))
                {
                    ControllerContext.HttpContext.Session["Username"] = loginData.Username;
                    ControllerContext.HttpContext.Session["Password"] = loginData.Password;
                    ControllerContext.HttpContext.Session["id"] = loginData.Id;
                    ControllerContext.HttpContext.Session["role"] = loginData.Role;


                    if (loginData.Username == model.Username && loginData.Password == model.Password)
                    {
                        return RedirectToAction("Dashboard", "Dashboard", new { area = " " });
                    }
                }
                else
                {
                    ViewBag.AlertMessage = "Invalid Login Credentials.";
                }


            }
            return View("Login", model);
        }

        public ActionResult registartionForm()
        {
           
            
               // Registation obj1 = new Registation();
               // //DAC abc = new DAC();
               // DataTable dt = new DataTable();

               // dt = _dac.dropDown();
               // List<SelectListItem> roleoptions = dt.AsEnumerable().Select(row => new SelectListItem
               // {
               //     Value = row["DocId"].ToString(),
               //     Text = row["Role"].ToString()
               // }).ToList();

               // //var model = new Registation
               // //{
               // //   roleList = roleoptions
               // //};
               return View("registartionForm");
            
            //return Json(roleoptions, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult UpdatePassword(ForgotPasswordModel model)
        {
            try
            {
                var updatemodel = _dac.UpdatePassword(model);

                return Json(new { success = true, Message = "password updated successfully", updatemodel });
            }
            catch (Exception ex)
            {
                // Log or print the exception details
                return Json((success: false, error: ex.Message));
            }
        }
    }
}