using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health_Management_System.Models
{
    public class Registation
    {

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "First Name Contains Only Characters Letter")]
        public string firstName { get; set; }


        [Display(Name = "Middle Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Middle Name Contains Only Characters Letter")]
        public string middleName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Last Name Contains Only Characters Letter")]
        public string lastName { get; set; }


        [Display(Name = "Designation")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Designation Contains Only Characters Letter")]
        public string designation { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a 10-digit mobile number.")]
        public string mobNumber { get; set; }

        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Address Contains Only Characters Letter")]
        public string address { get; set; }

        [Display(Name = "Role")]

        public string role { get; set; }
        public List<SelectListItem> roleList { get; set; }

    }
}