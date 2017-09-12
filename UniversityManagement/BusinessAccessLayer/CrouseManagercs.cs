using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.DataAccessLayer;
using UniversityManagement.Models;
namespace UniversityManagement.BussinessAccessLayer
{
    public class CrouseManagercs
    {
        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            DepartmentGateway departmentGateway=new DepartmentGateway();
           
            return departmentGateway.GetAllDepartmentForDropdown();
        }
        public int SaveCourse(Course course)
        {
            CourseGateway courseGateway = new CourseGateway();
            if (courseGateway.GetNoOfCourseByCourseCode(course) > 0)
            {
                return 0;
            }
            else
            {
                return courseGateway.SaveCourse(course);
            }
        }
        public List<SelectListItem> CourseDropdown(int departmentid)
        {
            CourseGateway courseGateway = new CourseGateway();
            return courseGateway.CourseDropdown(departmentid);
        }
        public Course GetCourseNameAndCredityCourseCode(int courseid)
        {
            CourseGateway courseGateway = new CourseGateway();
           return courseGateway.GetCourseNameAndCredityCourseCode(courseid);
        }

    }
}