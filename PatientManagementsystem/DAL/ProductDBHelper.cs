using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PatientManagementsystem.DAL
{
    public class ProductDBHelper
    {
        private SqlConnection con;
        private void Connection()
        {
            string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\180933\\source\\repos\\PatientManagementSystem\\PatientManagementsystem\\App_Data\\PatientDB.mdf;Integrated Security=True";
            con = new SqlConnection(constring);
        }
        public bool CreateProductDetails(Product obj)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CreateProduct", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Product_id", obj.ProductId);
            cmd.Parameters.AddWithValue("@Product_Name", obj.ProductName);
            cmd.Parameters.AddWithValue("@Category", obj.Category);
            cmd.Parameters.AddWithValue("@MinQuantity", obj.MinQuantity);
            cmd.Parameters.AddWithValue("@Reorder", obj.Reorder);
            cmd.Parameters.AddWithValue("@UOM", obj.UOM);
           

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Product> GetAllProduct()
        {
            Connection();
            List<Product> ProductList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetAllProduct", con);
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
                    ProductList.Add(
                        new Product
                        {
                            ProductId = Convert.ToInt32(dr["Product_id"]),
                            ProductName = Convert.ToString(dr["Product_Name"]),
                            Category = Convert.ToString(dr["Category"]),
                            MinQuantity = Convert.ToInt32(dr["MinQuantity"]),
                            Reorder = Convert.ToString(dr["Reorder"]),
                            UOM = Convert.ToInt32(dr["UOM"]),

                        });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ProductList;
        }


        public Product GetProductById(int id)
        {
            Connection();
            Product Product = new Product();

            SqlCommand cmd = new SqlCommand("GetByProductId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Product.ProductId = Convert.ToInt32(dt.Rows[0]["Product_id"]);
                Product.ProductName = Convert.ToString(dt.Rows[0]["Product_Name"]);
                Product.Category = Convert.ToString(dt.Rows[0]["Category"]);
                Product.MinQuantity = Convert.ToInt32(dt.Rows[0]["MinQuantity"]);
                Product.Reorder = Convert.ToString(dt.Rows[0]["Reorder"]);
                Product.UOM = Convert.ToInt32(dt.Rows[0]["UOM"]);
                
                dt.Clear();
            }
            else
            {
                return null;
            }
            con.Close();
            return Product;
        }

        //To Update Product details    
        public bool UpdateProduct(Product obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Product_id", obj.ProductId);
            com.Parameters.AddWithValue("@Product_Name", obj.ProductName);
            com.Parameters.AddWithValue("@Category", obj.Category);
            com.Parameters.AddWithValue("@MinQuantity", obj.MinQuantity);
            com.Parameters.AddWithValue("@Reorder", obj.Reorder);
            com.Parameters.AddWithValue("@UOM", obj.UOM);
            
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

        //public bool DeleteData(int id)
        //{
        //    Connection();
        //    SqlCommand cmd = new SqlCommand("DeleteProduct", con)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };

        //    cmd.Parameters.AddWithValue("@Product_id", id);

        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();

        //    if (i >= 1)
        //        return true;
        //    else
        //        return false;
        //}
    }
}