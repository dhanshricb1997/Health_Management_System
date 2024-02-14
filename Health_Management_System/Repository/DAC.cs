using Health_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Health_Management_System.Repository
{
    public class DAC
    {
        private string connectionString;

        public DAC(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public void addData()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO People (Name, Age) VALUES (@Name, @Age)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public loginModel userlogin(loginModel model)
        {
            loginModel modelList = new loginModel();
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM tbl_user_login WHERE Username = @Username AND Password = @Password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", model.Username);
                sqlCommand.Parameters.AddWithValue("@Password", model.Password);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    modelList.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                    modelList.Username = dataTable.Rows[0]["Username"].ToString();
                    modelList.Password = dataTable.Rows[0]["Password"].ToString();
                    modelList.Role = dataTable.Rows[0]["role"].ToString();
                    // Map data from DataTable to your model
                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    loginModel login = new loginModel
                    //    {
                    //        Id = Convert.ToInt32(row["Id"]),
                    //        Username = row["Username"].ToString(),
                    //        Password = row["Password"].ToString(),
                    //        Role = row["role"].ToString()
                    //    };

                    //    modelList.Add(login);
                    //}
                }

                return modelList;
            }
        }


    }

}