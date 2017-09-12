using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.BussinessAccessLayer;
using UniversityManagement.Models;
namespace UniversityManagement.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        [HttpGet]
        public ActionResult Index()
        {
            CrouseManagercs courseManager=new CrouseManagercs();
            List<SelectListItem> departmentlist = courseManager.GetAllDepartmentForDropdown();
            ViewBag.departmentlist = departmentlist;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Course course)
        {
            if (ModelState.IsValid)
            {
                CrouseManagercs courseManager = new CrouseManagercs();
                if (courseManager.SaveCourse(course) == 0)
                {
                    ViewBag.result = "Already exits";
                }
                else
                {
                    ViewBag.result = "Insert successfully";
                }
                List<SelectListItem> departmentlist = courseManager.GetAllDepartmentForDropdown();
                ViewBag.departmentlist = departmentlist;
            }
            return View();
        }
    }
}
