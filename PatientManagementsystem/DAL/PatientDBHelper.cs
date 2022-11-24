using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace PatientManagementsystem.DAL
{
    public class PatientDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreatePatientDetails(Patient obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreatePatient", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Patient_id", obj.Patient_Id);
            cmd.Parameters.AddWithValue("@Patient_FName", obj.FirstName);
            cmd.Parameters.AddWithValue("@Patient_lName", obj.LastName);
            cmd.Parameters.AddWithValue("@Hospital_id", obj.Hospital_id);
            cmd.Parameters.AddWithValue("@Doctor_id", obj.Doctor_id);
            cmd.Parameters.AddWithValue("@Patient_Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Patient_Age", obj.Age);
            cmd.Parameters.AddWithValue("@Patient_Address", obj.Address);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@DeletedStatus", 1);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Patient> GetAll(int id)
        {
            Connection();
            List<Patient> PatientList = new List<Patient>();

            SqlCommand cmd = new SqlCommand("GetAllPatients", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Hospital_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    PatientList.Add(
                        new Patient
                        {
                            Patient_Id = Convert.ToInt32(dr["Patient_id"]),
                            FirstName = Convert.ToString(dr["Patient_FName"]),
                            LastName = Convert.ToString(dr["Patient_LName"]),
                            Hospital_id = Convert.ToInt32(dr["Hospital_id"]),
                            Doctor_id = Convert.ToInt32(dr["Doctor_id"]),
                            Gender = Convert.ToString(dr["Patient_Gender"]),
                            Age = Convert.ToInt32(dr["Patient_Age"]),
                            Address = Convert.ToString(dr["Patient_Address"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["Email"])
                            

                        });
                }
                }
            catch (Exception)
            {
                throw;
            }
            return PatientList;
        }


        public Patient GetPatientById(int id)
        {
            Connection();
            Patient Patient = new Patient();

            SqlCommand cmd = new SqlCommand("GetById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Patient_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Patient.Patient_Id = Convert.ToInt32(dt.Rows[0]["Patient_Id"]);
                Patient.FirstName = Convert.ToString(dt.Rows[0]["Patient_FName"]);
                Patient.LastName = Convert.ToString(dt.Rows[0]["Patient_LName"]);
                Patient.Hospital_id = Convert.ToInt32(dt.Rows[0]["Hospital_id"]);
                Patient.Doctor_id = Convert.ToInt32(dt.Rows[0]["Doctor_id"]);
                Patient.Gender = Convert.ToString(dt.Rows[0]["Patient_Gender"]);
                Patient.Age = Convert.ToInt32(dt.Rows[0]["Patient_Age"]);
                Patient.Address = Convert.ToString(dt.Rows[0]["Patient_Address"]);
                Patient.PhoneNumber = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                Patient.Email = Convert.ToString(dt.Rows[0]["Email"]);
                dt.Clear();
            }
            else
            {
                return null;
            }
            con.Close();
            return Patient;
        }

        public List<Patient> GetPatientsByDoctorId(int id, int HospitalId)
        {
            Connection();
            List<Patient> PatientList = new List<Patient>();

            SqlCommand cmd = new SqlCommand("GetPatientsByDoctorId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_id", id);
            cmd.Parameters.AddWithValue("@Hospital_id", HospitalId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    PatientList.Add(
                        new Patient
                        {
                            Patient_Id = Convert.ToInt32(dr["Patient_id"]),
                            FirstName = Convert.ToString(dr["Patient_FName"]),
                            LastName = Convert.ToString(dr["Patient_LName"]),
                            Hospital_id = Convert.ToInt32(dr["Hospital_id"]),
                            Doctor_id = Convert.ToInt32(dr["Doctor_id"]),
                            Gender = Convert.ToString(dr["Patient_Gender"]),
                            Age = Convert.ToInt32(dr["Patient_Age"]),
                            Address = Convert.ToString(dr["Patient_Address"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["Email"])


                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PatientList;
        }



        //To Update Patient details    
        public bool UpdatePatient(Patient obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdatePatient", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Patient_id", obj.Patient_Id);
            com.Parameters.AddWithValue("@Patient_FName", obj.FirstName);
            com.Parameters.AddWithValue("@Patient_LName", obj.LastName);
            com.Parameters.AddWithValue("@Hospital_id", obj.Hospital_id);
            com.Parameters.AddWithValue("@Doctor_id", obj.Doctor_id);
            com.Parameters.AddWithValue("@Patient_Gender", obj.Gender);
            com.Parameters.AddWithValue("@Patient_Age", obj.Age);
            com.Parameters.AddWithValue("@Patient_Address", obj.Address);
            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@DeletedStatus", 1);


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
            SqlCommand cmd = new SqlCommand("DeletePatient", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Patient_id", id);

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