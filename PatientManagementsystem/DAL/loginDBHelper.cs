using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using PatientManagementsystem.Models;

namespace PatientManagementsystem.DAL
{
    public class loginDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        
        public Employee GetEmployeeByUserName(String UserName)
        {
            Connection();
            Employee Employee = new Employee();

            SqlCommand cmd = new SqlCommand("GetByEmployeeUserName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Employee.EmployeeId = Convert.ToInt32(dt.Rows[0]["Employee_id"]);
                Employee.FirstName = Convert.ToString(dt.Rows[0]["Employee_FName"]);
                Employee.LastName = Convert.ToString(dt.Rows[0]["Employee_LName"]);
                Employee.HospitalId = Convert.ToInt32(dt.Rows[0]["Hospital_id"]);
                Employee.Gender = Convert.ToString(dt.Rows[0]["Employee_Gender"]);
                Employee.PhoneNumber = Convert.ToString(dt.Rows[0]["E_PhoneNumber"]);
                Employee.Address = Convert.ToString(dt.Rows[0]["E_Address"]);
                Employee.Department = Convert.ToString(dt.Rows[0]["Department"]);
                Employee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                Employee.Designation = Convert.ToString(dt.Rows[0]["Designation"]);
                Employee.isactive = Convert.ToInt32(dt.Rows[0]["isactive"]);
                Employee.Password = Convert.ToString(dt.Rows[0]["Password"]);
                Employee.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                Employee.Admin = Convert.ToBoolean(dt.Rows[0]["Admin"]);
                dt.Clear();
            }
            else
            {
                return null;
            }
           
            return Employee;
        }

      
    }
}