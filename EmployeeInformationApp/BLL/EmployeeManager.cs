using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL;
using EmployeeInformationApp.Model;

namespace EmployeeInformationApp.BLL
{
   public class EmployeeManager
    {
       EmployeeDataAccess employeeGateway = new EmployeeDataAccess();
        internal string Save(Model.Employee aEmployee)
        {
            
                Employee employee = GetEmployeeByEmail(aEmployee.Email);
                if (employee != null)
                {
                    return "Email Already Exists";
                }
                else
                {
                    int result = employeeGateway.Save(aEmployee);
                    if (result > 0)
                    {
                        return "Employee Saved Successfully";
                    }
                    else
                    {
                        return "Failed to save employee";
                    }
                }

        }

        private Employee GetEmployeeByEmail(string email)
        {
            return employeeGateway.GetEmployeeByEmail(email);
        }

        internal List<Model.Employee> GetAllEmployees()
        {
            return employeeGateway.GetAllEmployees();
        }

        internal List<Model.Employee> GetEmployeeByName(string name)
        {
            return employeeGateway.GetEmployeeByName(name);
        }

        internal Model.Employee GetEmployeeById(int employeeId)
        {
            return employeeGateway.GetEmployeeById(employeeId);
        }

        internal string Delete(int employeeId)
        {
            int result = employeeGateway.Delete(employeeId);
            if (result > 0)
            {
                return "Deleted Successfully";
            }
            else
            {
                return "Failed To Delete";
            }
        }

        internal string Update(Employee employee)
        {
            int result = employeeGateway.Update(employee);
            if (result > 0)
            {
                return "Updated Successfully";
            }
            else
            {
                return "Failed To Update";
            }
        }
    }
}
