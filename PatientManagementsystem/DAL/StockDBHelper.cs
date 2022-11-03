using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.DAL
{
    public class StockDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreateStockDetails(Stock obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreateStock", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Product_id", obj.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
            cmd.Parameters.AddWithValue("@UOM", obj.UOM);
            cmd.Parameters.AddWithValue("@BatchNumber", obj.BatchNumber);
            cmd.Parameters.AddWithValue("@Expiary_Date", obj.ExpiryDate);
           

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Stock> GetAllStock()
        {
            Connection();
            List<Stock> StockList = new List<Stock>();

            SqlCommand cmd = new SqlCommand("GetAllStock", con);
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
                    StockList.Add(
                        new Stock
                        {
                            ProductId = Convert.ToInt32(dr["Product_id"]),
                            Quantity = Convert.ToString(dr["Quantity"]),
                            UOM = Convert.ToInt32(dr["UOM"]),
                            BatchNumber = Convert.ToString(dr["BatchNumber"]),
                            ExpiryDate = Convert.ToDateTime(dr["Expiary_Date"]),
                           

                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return StockList;
        }


        public Stock GetStockById(int id)
        {
            Connection();
            Stock Stock = new Stock();

            SqlCommand cmd = new SqlCommand("GetByStockId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Stock.ProductId = Convert.ToInt32(dt.Rows[0]["Product_id"]);
                Stock.Quantity = Convert.ToString(dt.Rows[0]["Quantity"]);
                Stock.UOM = Convert.ToInt32(dt.Rows[0]["UOM"]);
                Stock.BatchNumber = Convert.ToString(dt.Rows[0]["BatchNumber"]);
                Stock.ExpiryDate = Convert.ToDateTime(dt.Rows[0]["Expiary_Date"]);
              
                dt.Clear();
            }
            else
            {
                return null;
            }
            con.Close();
            return Stock;
        }

        //To Update Stock details    
        public bool UpdateStock(Stock obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateStock", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Product_id", obj.ProductId);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@UOM", obj.UOM);
            com.Parameters.AddWithValue("@BatchNumber", obj.BatchNumber);
            com.Parameters.AddWithValue("@Expiary_Date", obj.ExpiryDate);
          

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
    }
}