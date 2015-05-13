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
   public class EmployeeDataAccess
   {
       private string connectionString =
           ConfigurationManager.ConnectionStrings["employeeConnectionString"].ConnectionString;
        internal int Save(Model.Employee aEmployee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Employee_insert";
            SqlCommand command = new SqlCommand(query,connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", aEmployee.Name);
            command.Parameters.AddWithValue("@email", aEmployee.Email);
            command.Parameters.AddWithValue("@address", aEmployee.Address);
            command.Parameters.AddWithValue("@designationId", aEmployee.DesignationId);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;

        }
       List<Employee> employees = new List<Employee>(); 
        internal List<Model.Employee> GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM EmployeesTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee aEmployee = new Employee();
                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.Name = reader[1].ToString();
                aEmployee.Email = reader[2].ToString();
                aEmployee.Address = reader[3].ToString();
                aEmployee.DesignationId = int.Parse(reader[4].ToString());
                employees.Add(aEmployee);
            }
            reader.Close();
            connection.Close();
            return employees;
        }

       List<Employee> searchList = new List<Employee>(); 
        internal List<Employee> GetEmployeeByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "searchByName";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee aEmployee = new Employee();
                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.Name = reader[1].ToString();
                aEmployee.Email = reader[2].ToString();
                aEmployee.Address = reader[3].ToString();
                aEmployee.DesignationId = int.Parse(reader[4].ToString());
                searchList.Add(aEmployee);
            }
            reader.Close();
            connection.Close();
            return searchList;
        }

        internal Employee GetEmployeeById(int employeeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "EmployeeById";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", employeeId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee aEmployee = null;
            while (reader.Read())
            {
                aEmployee = new Employee();
                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.Name = reader[1].ToString();
                aEmployee.Email = reader[2].ToString();
                aEmployee.Address = reader[3].ToString();
                aEmployee.DesignationId = int.Parse(reader[4].ToString());
                
            }
            reader.Close();
            connection.Close();
            return aEmployee;
        }

        internal int Delete(int employeeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "delete_employee";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", employeeId);
            connection.Open();
            int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            return affectedRow;
        }

        internal Employee GetEmployeeByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "employeeByEmail";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@email", email);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee aEmployee = null;
            while (reader.Read())
            {
                aEmployee = new Employee();
                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.Name = reader[1].ToString();
                aEmployee.Email = reader[2].ToString();
                aEmployee.Address = reader[3].ToString();
                aEmployee.DesignationId = int.Parse(reader[4].ToString());

            }
            reader.Close();
            connection.Close();
            return aEmployee;
        }

        internal int Update(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "updateEmployee";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("email", employee.Email);
            command.Parameters.AddWithValue("@address", employee.Address);
            command.Parameters.AddWithValue("@designationId", employee.DesignationId);
            command.Parameters.AddWithValue("@id", employee.Id);
            connection.Open();
             int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            return affectedRow;
        }
   }
}
