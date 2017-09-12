using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public string DepartmentName { get; set; }
        public string SemesterName { get; set; }
    }
}