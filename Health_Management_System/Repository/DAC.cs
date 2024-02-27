using Health_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                string query = "SELECT * FROM tbl_user_login WHERE userName = @Username AND password = @Password AND role = @role";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", model.Username);
                sqlCommand.Parameters.AddWithValue("@Password", model.Password);
                sqlCommand.Parameters.AddWithValue("@role", model.Role);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    //modelList.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
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

        public List<Registation> getAllDetails(string searchTerm)
        {
            List<Registation> listDetails = new List<Registation>();
        
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM tbl_user_registration";
                string query1 = "SELECT * FROM tbl_user_registration WHERE " +
                       "firstName LIKE @searchTerm OR " +
                       "lastName LIKE @searchTerm OR " +
                       "mobNumber LIKE @searchTerm";
                SqlCommand sqlCommand = new SqlCommand(query1, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                // SqlCommand selectCMD = new SqlCommand("SELECT * FROM tb_UserDetail", db);
                sqlCommand.CommandTimeout = 30;
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = sqlCommand;
                DataSet customerDS = new DataSet();
                
                customerDA.Fill(customerDS, "tb_UserDetail");
                DataTable dt = customerDS.Tables["tb_UserDetail"];

                // Map data from DataTable to your model
                foreach (DataRow row in dt.Rows)
                {
                    Registation details = new Registation
                    {
                        //firstName = row["firstName"].ToString(),
                        //lastName = row["lastName"].ToString(),
                        //middleName = row["middleName"].ToString(),
                        //role = row["role"].ToString(),
                        //designation = row["designation"].ToString(),
                        //address = row["address"].ToString(),
                        //mobNumber = row["mobNumber"].ToString()
                    };

                    listDetails.Add(details);
                }
                return listDetails;
            }
        }

    }

                       
}