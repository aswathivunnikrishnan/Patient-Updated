using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.DAL
{
    public class HospitalDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreateHospitalDetails(Hospital obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreateHospital", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Hospital_id", obj.Hospital_Id);
            cmd.Parameters.AddWithValue("@Hospital_Name", obj.Hospital_Name);
            cmd.Parameters.AddWithValue("@StateName", obj.StateName);
            cmd.Parameters.AddWithValue("@District", obj.District);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@Office_PhoneNumber", obj.Office_PhoneNumber);

            

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Hospital> GetAllHospitalDetails()
        {
            Connection();
            List<Hospital> HospitalList = new List<Hospital>();

            SqlCommand cmd = new SqlCommand("GetAllHospital", con);
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
                    HospitalList.Add(
                        new Hospital
                        {
                            Hospital_Id= Convert.ToInt32(dr["Hospital_id"]),
                            Hospital_Name = Convert.ToString(dr["Hospital_Name"]),
                            StateName = Convert.ToString(dr["StateName"]),
                            District = Convert.ToString(dr["District"]),
                            City = Convert.ToString(dr["City"]),
                            Office_PhoneNumber = Convert.ToString(dr["Office_PhoneNumber"]),
                           

                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return HospitalList;
        }


        public Hospital GetHospitalDetailsById(int id)
        {
            Connection();
            Hospital Hospital = new Hospital();

            SqlCommand cmd = new SqlCommand("GetByHospitalId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Hospital_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Hospital.Hospital_Id = Convert.ToInt32(dt.Rows[0]["Hospital_Id"]);
                Hospital.Hospital_Name = Convert.ToString(dt.Rows[0]["Hospital_Name"]);
                Hospital.StateName = Convert.ToString(dt.Rows[0]["StateName"]);
                Hospital.District = Convert.ToString(dt.Rows[0]["District"]);
                Hospital.City = Convert.ToString(dt.Rows[0]["City"]);
                Hospital.Office_PhoneNumber = Convert.ToString(dt.Rows[0]["Office_PhoneNumber"]);
                
                dt.Clear();
            }
            else
            {
                return null;
            }
            con.Close();
            return Hospital;
        }

        //To Update Hospital details    
        public bool UpdateHospital(Hospital obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateHospital", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Hospital_id", obj.Hospital_Id);
            com.Parameters.AddWithValue("@Hospital_Name", obj.Hospital_Name);
            com.Parameters.AddWithValue("@StateName", obj.StateName);
            com.Parameters.AddWithValue("@District", obj.District);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Office_PhoneNumber", obj.Office_PhoneNumber);


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
            SqlCommand cmd = new SqlCommand("DeleteHospital", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Hospital_id", id);

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