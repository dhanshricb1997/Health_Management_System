using System;
using System.Collections.Generic;
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
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult registartionForm()
        {
           
            
                Registation obj1 = new Registation();
                DAC abc = new DAC();
                DataTable dt = new DataTable();

                dt = abc.dropDown();
                List<SelectListItem> roleoptions = dt.AsEnumerable().Select(row => new SelectListItem
                {
                    Value = row["DocId"].ToString(),
                    Text = row["Role"].ToString()
                }).ToList();

                var model = new Registation
                {
                   role = roleoptions
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