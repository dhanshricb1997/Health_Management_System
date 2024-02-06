using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Health_Management_System.Repository
{
    public class DAC
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void addData()
        {
            
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "INSERT INTO People (Name, Age) VALUES (@Name, @Age)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Name", person.Name);
                    //command.Parameters.AddWithValue("@Age", person.Age);

                    command.ExecuteNonQuery();
                }
            }
        }
        
        
    }

}