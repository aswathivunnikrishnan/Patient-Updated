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
                dt.Clear();
            }
            else
            {
                return null;
            }
           
            return Employee;
        }

        public Doctor GetDoctorByPhoneNumber(string PhoneNumber)
        {
            Connection();
            Doctor Doctor = new Doctor();

            SqlCommand cmd = new SqlCommand("GetByDoctorPhoneNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@D_PhoneNumber", PhoneNumber);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Doctor.Doctor_id = Convert.ToInt32(dt.Rows[0]["Doctor_Id"]);
                Doctor.Doctor_Name = Convert.ToString(dt.Rows[0]["Doctor_Name"]);
                Doctor.Hospital_id = Convert.ToInt32(dt.Rows[0]["Hospital_id"]);
                Doctor.Speciality = Convert.ToString(dt.Rows[0]["Speciality"]);
                Doctor.Qualification = Convert.ToString(dt.Rows[0]["Qualification"]);
                Doctor.D_PhoneNumber = Convert.ToString(dt.Rows[0]["D_PhoneNumber"]);
                Doctor.No_of_patientperday = Convert.ToInt32(dt.Rows[0]["No_of_patientperday"]);
                Doctor.Fee = Convert.ToInt32(dt.Rows[0]["Fee"]);
                Doctor.Password = Convert.ToString(dt.Rows[0]["Password"]);
                dt.Clear();
            }
            else
            {
                return null;
            }
            return Doctor;
        }
    }
}