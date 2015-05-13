using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.Model;

namespace EmployeeInformationApp.DAL
{
    
   public class DesignationDataAccess
   {
       private string connectionString =
           ConfigurationManager.ConnectionStrings["employeeConnectionString"].ConnectionString;

       public int Insert(Designation designation)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "designation_insert";
           SqlCommand command = new SqlCommand(query,connection);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.Clear();
           command.Parameters.AddWithValue("@code", designation.Code);
           command.Parameters.AddWithValue("@title", designation.Title);
           connection.Open();
           int affectedRow = command.ExecuteNonQuery();
           connection.Close();
           return affectedRow;
       }
       public List<Designation> designations = new List<Designation>();

       public List<Designation> GetAllDesignations()
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM DesignationsTbl";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               Designation aDesignation = new Designation();
               aDesignation.Id = int.Parse(reader[0].ToString());
               aDesignation.Code = reader[1].ToString();
               aDesignation.Title = reader[2].ToString();
               designations.Add(aDesignation);
           }
           reader.Close();
           connection.Close();
           return designations;
       }

       internal Designation GetDesignationByCode(string name)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM DesignationsTbl WHERE Title = '" + name + "'";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           Designation aDesignation = null;
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               aDesignation = new Designation();
               aDesignation.Id = int.Parse(reader[0].ToString());
               aDesignation.Code = reader[1].ToString();
               aDesignation.Title = reader[2].ToString();
               }
           reader.Close();
           connection.Close();
           return aDesignation;
       }
   }
}
