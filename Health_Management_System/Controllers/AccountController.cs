using Health_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            if (ModelState.IsValid)
            {
               
            }
            return View(model);
        }
        public ActionResult registartionForm()
        {
            return View();
        }
    }
}