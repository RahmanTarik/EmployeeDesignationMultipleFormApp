using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL;
using EmployeeInformationApp.Model;

namespace EmployeeInformationApp.BLL
{
   public class DesignationManager
    {
       DesignationDataAccess gateway = new DesignationDataAccess();

       public string Insert(Designation designation)
       {
           Designation adesignation = GetDesignationByName(designation.Title);
           if (adesignation !=null)
           {
               return "Designation Already Exsits";
           }
           else
           {
               int result = gateway.Insert(designation);
               if (result > 0)
               {
                   return "Designation Saved Successfully";
               }
               else
               {
                   return "Failed to save designation";
               }
           }
           
       }

       private Designation GetDesignationByName(string name)
       {
           return gateway.GetDesignationByCode(name);
       }

       public List<Designation> GetAllDesignations()
       {
           return gateway.GetAllDesignations();
       }


    }
}
