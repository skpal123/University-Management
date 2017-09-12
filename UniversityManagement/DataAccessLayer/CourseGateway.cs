using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using UniversityManagement.Models;
using System.Web.Mvc;
namespace UniversityManagement.DataAccessLayer
{
    public class CourseGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["UniversityManagement"].ConnectionString.ToString();
        public int SaveCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into tblCourse values(@Code,@Name,@Credit,@Description,@DepartmentName,@SemesterName,1)", con);
                cmd.Parameters.AddWithValue("@Code",course.CourseCode);
                cmd.Parameters.AddWithValue("@Name",course.CourseName);
                cmd.Parameters.AddWithValue("@Credit",course.CourseCredit);
                cmd.Parameters.AddWithValue("@Description",course.CourseDescription);
                cmd.Parameters.AddWithValue("@DepartmentName",course.DepartmentName);
                cmd.Parameters.AddWithValue("@SemesterName",course.SemesterName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public List<Department> GetAllCourse()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select DepartmentCode,DepartmentName from tblDepartment", con);
                List<Department> departmentlist = new List<Department>();
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department department = new Department();
                    department.DepartmentCode = rdr["DepartmentCode"].ToString();
                    department.DepartmentName = rdr["DepartmentName"].ToString();
                    departmentlist.Add(department);
                }
                return departmentlist;
            }
        }
        public int GetNoOfCourseByCourseCode(Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from tblCourse where CourseCode=@Code", con);
                cmd.Parameters.AddWithValue("@Code", course.CourseCode);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Course GetCourseNameAndCredityCourseCode(int courseid)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select CourseName,CourseCredit from tblCourse where CourseId=@CourseId", con);
                cmd.Parameters.AddWithValue("@CourseId", courseid);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Course course = new Course();
                while (rdr.Read())
                {
                    
                    course.CourseName = rdr["CourseName"].ToString();
                    course.CourseCredit =Convert.ToInt32( rdr["CourseCredit"].ToString());
                   
                }
                return course; 
            }
        }
        public List<SelectListItem> CourseDropdown(int departmentid)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select CourseId,CourseCode from tblCourse where DepartmentName=@departmentid", con);
                cmd.Parameters.AddWithValue("@departmentid", departmentid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (DataRow drow in dt.Rows)
                {
                    list.Add(new SelectListItem { Value = drow["CourseId"].ToString(), Text = drow["CourseCode"].ToString() });
                }
                return list;
            }
        }
        //public JsonResult GetClassScheduleAndRoomAllocationByDepartmentName(int departmentid)
        //{
        
        //}
    }
}