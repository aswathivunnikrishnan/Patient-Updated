using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace DoctorManagementsystem.DAL
{
    public class DoctorDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreateDoctorDetails(Doctor obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreateDoctor", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Doctor_id", obj.Doctor_id);
            cmd.Parameters.AddWithValue("@Doctor_Name", obj.Doctor_Name);
            cmd.Parameters.AddWithValue("@Speciality", obj.Speciality);
            cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
            cmd.Parameters.AddWithValue("@D_PhoneNumber", obj.D_PhoneNumber);
           cmd.Parameters.AddWithValue("@No_of_Patientperday", obj.No_of_patientperday);
            cmd.Parameters.AddWithValue("@Fee", obj.Fee);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@DeletedStatus", 1);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Doctor> GetAll()
        {
            Connection();
            List<Doctor> DoctorList = new List<Doctor>();

            SqlCommand cmd = new SqlCommand("GetAllDoctor", con);
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
                    DoctorList.Add(
                        new Doctor
                        {
                            Doctor_id = Convert.ToInt32(dr["Doctor_id"]),
                            Doctor_Name = Convert.ToString(dr["Doctor_Name"]),
                            Speciality = Convert.ToString(dr["Speciality"]),
                            Qualification = Convert.ToString(dr["Qualification"]),
                            D_PhoneNumber = Convert.ToString(dr["D_PhoneNumber"]),
                            No_of_patientperday = Convert.ToInt32(dr["No_of_patientperday"]),
                            Fee = Convert.ToInt16(dr["Fee"]),
                            Password = Convert.ToString(dr["Password"]),



                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DoctorList;
        }

        public Doctor GetDoctorById(int id)
        {
            Connection();
            Doctor Doctor = new Doctor();

            SqlCommand cmd = new SqlCommand("GetByDoctorId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Doctor_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Doctor.Doctor_id= Convert.ToInt32(dt.Rows[0]["Doctor_Id"]);
                Doctor.Doctor_Name = Convert.ToString(dt.Rows[0]["Doctor_Name"]);
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
            con.Close();
            return Doctor;
        }

        //To Update Doctor details    
        public bool UpdateDoctor(Doctor obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateDoctor", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Doctor_id", obj.Doctor_id);
            com.Parameters.AddWithValue("@Doctor_Name", obj.Doctor_Name);
            com.Parameters.AddWithValue("@Speciality", obj.Speciality);
            com.Parameters.AddWithValue("@Qualification", obj.Qualification);
            com.Parameters.AddWithValue("@D_PhoneNumber", obj.D_PhoneNumber);
            com.Parameters.AddWithValue("@No_of_Patientperday", obj.No_of_patientperday);
            com.Parameters.AddWithValue("@Fee", obj.Fee);
            com.Parameters.AddWithValue("@Password", obj.Password);
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
            SqlCommand cmd = new SqlCommand("DeleteDoctor", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Doctor_id", id);

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