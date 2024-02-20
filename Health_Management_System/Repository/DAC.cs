using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Health_Management_System.Repository
{
    public class DAC
    {
        public DataTable dropDown()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Role");
            dt.Columns.Add("DocId");

            dt.Rows.Add("Doctor", "1");
            dt.Rows.Add("Nurse", "2");
            dt.Rows.Add("Patient", "3");
            dt.Rows.Add("Staff", "4");
            
            return dt;
        }
    }
}