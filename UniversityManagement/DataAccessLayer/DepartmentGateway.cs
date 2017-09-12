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
    public class DepartmentGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["UniversityManagement"].ConnectionString.ToString();
        public int SaveDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into tblDepartment values(@DepartmentCode,@DepartmentName)", con);
                cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                cmd.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public List<Department> GetAllDepartment()
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
        public int GetNoOfDepartmentByDeaprtmentCode(Department department)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from tblDepartment where DepartmentCode=@DepartmentCode", con);
                cmd.Parameters.AddWithValue("@DepartmentCode", department.DepartmentCode);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblDepartment", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem { Text = "select Department", Value = "0" });
                foreach (DataRow drow in dt.Rows)
                {
                    list.Add(new SelectListItem { Value = drow["DepartmentId"].ToString(), Text = drow["DepartmentName"].ToString() });
                }
                return list;
            }
        }
        public string DeaprtmentCodeByDepartmentId(int Departmentd)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select DepartmentName from tblDepartment where DepartmentId=@DepartmentId", con);
                cmd.Parameters.AddWithValue("@DepartmentId", Departmentd);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                return rdr["DepartmentName"].ToString();
            }
        }
    }
}