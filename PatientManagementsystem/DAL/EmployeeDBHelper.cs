using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using PatientManagementsystem.Models;

namespace EmployeeManagementsystem.DAL
{
    public class EmployeeDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreateEmployeeDetails(Employee obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreateEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Employee_id", obj.EmployeeId);
            cmd.Parameters.AddWithValue("@Employee_FName", obj.FirstName);
            cmd.Parameters.AddWithValue("@Employee_LName", obj.LastName);
            cmd.Parameters.AddWithValue("@Employee_Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@E_PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@E_Address", obj.Address);
            cmd.Parameters.AddWithValue("@Department", obj.Department);
            cmd.Parameters.AddWithValue("@DOJ", obj.DOJ);
            cmd.Parameters.AddWithValue("@Designation",obj.Designation);
            cmd.Parameters.AddWithValue("@isactive",1);
            cmd.Parameters.AddWithValue("@Password", obj.Password);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Employee> GetAllEmployees()
        {
            Connection();
            List<Employee> EmployeeList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("GetAllEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    EmployeeList.Add(
                        new Employee
                        {
                            EmployeeId = Convert.ToInt32(dr["Employee_id"]),
                            FirstName = Convert.ToString(dr["Employee_FName"]),
                            LastName = Convert.ToString(dr["Employee_LName"]),
                            Gender = Convert.ToString(dr["Employee_Gender"]),
                            PhoneNumber = Convert.ToString(dr["E_PhoneNumber"]),
                            Address = Convert.ToString(dr["E_Address"]),
                            Department = Convert.ToString(dr["Department"]),
                            DOJ = Convert.ToDateTime(dr["DOJ"]),
                            Designation = Convert.ToString(dr["Designation"]),
                            isactive = Convert.ToInt32(dr["isactive"]),
                            Password = Convert.ToString(dr["Password"]),


                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return EmployeeList;
        }


        public Employee GetEmployeeById(int id)
        {
            Connection();
            Employee Employee = new Employee();

            SqlCommand cmd = new SqlCommand("GetByEmployeeId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Employee.EmployeeId = Convert.ToInt32(dt.Rows[0]["Employee_id"]);
                Employee.FirstName = Convert.ToString(dt.Rows[0]["Employee_FName"]);
                Employee.LastName = Convert.ToString(dt.Rows[0]["Employee_LName"]);
                Employee.Gender = Convert.ToString(dt.Rows[0]["Employee_Gender"]);
                Employee.PhoneNumber = Convert.ToString(dt.Rows[0]["E_PhoneNumber"]);
                Employee.Address = Convert.ToString(dt.Rows[0]["E_Address"]);
                Employee.PhoneNumber = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                Employee.Department = Convert.ToString(dt.Rows[0]["Department"]);
                Employee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                Employee.Designation = Convert.ToString(dt.Rows[0]["Designation"]);
                Employee.isactive = Convert.ToInt32(dt.Rows[0]["isactive"]);
                Employee.Password = Convert.ToString(dt.Rows[0]["Password"]);
                dt.Clear();
            }
            else
            {
                return null;
            }
            con.Close();
            return Employee;
        }

        public bool UpdateEmployee(Employee obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateEmployee", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Employee_id", obj.EmployeeId);
            com.Parameters.AddWithValue("@Employee_FName", obj.FirstName);
            com.Parameters.AddWithValue("@Employee_LName", obj.LastName);
            com.Parameters.AddWithValue("@Employee_Gender", obj.Gender);
            com.Parameters.AddWithValue("@E_PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@E_Address", obj.Address);
            com.Parameters.AddWithValue("@Department", obj.Department);
            com.Parameters.AddWithValue("@DOJ", obj.DOJ);
            com.Parameters.AddWithValue("@Designation", obj.Designation);
            com.Parameters.AddWithValue("@isactive", 1);
            com.Parameters.AddWithValue("@Password", obj.Password);


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Employee_id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
