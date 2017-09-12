using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.DataAccessLayer;
using UniversityManagement.Models;
namespace UniversityManagement.BussinessAccessLayer
{
    public class DepartmentManager
    {
        public List<Department> GetAllDepartment()
        {
            DepartmentGateway departmentGateway=new DepartmentGateway();
            return departmentGateway.GetAllDepartment();
        }
        public int SaveDepartment(Department department)
        {
            DepartmentGateway departmentGateway = new DepartmentGateway();
            if (departmentGateway.GetNoOfDepartmentByDeaprtmentCode(department)>0)
            {
                return 0;
            }
            else
            {
                return departmentGateway.SaveDepartment(department);
            }
        }
        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            DepartmentGateway departmentGateway = new DepartmentGateway();
            return departmentGateway.GetAllDepartmentForDropdown();
        }
        public string DeaprtmentCodeByDepartmentId(int DepartmentId)
        {
            DepartmentGateway departmentGateway = new DepartmentGateway();
            return departmentGateway.DeaprtmentCodeByDepartmentId(DepartmentId);
        }
    }
}