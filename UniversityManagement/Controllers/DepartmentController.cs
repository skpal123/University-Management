using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.BussinessAccessLayer;
using UniversityManagement.Models;
namespace UniversityManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index( Department department)
        {
            
            if (ModelState.IsValid)
            {
                DepartmentManager departmentManager = new DepartmentManager();
                //departmentManager.SaveDepartment(department);
                if (departmentManager.SaveDepartment(department) > 0)
                {
                    ViewBag.result = "Insert succesfffully";
                }
                else
                {
                    ViewBag.result = "Already exits";
                }
            }
            
            return View();
        }
        public ActionResult showAllDepartment()
        {
            DepartmentManager departmentManager = new DepartmentManager();
          List<Department> departmentlist= departmentManager.GetAllDepartment();
          ViewBag.departmentlist = departmentlist;
          return View();
        }
    }
}
