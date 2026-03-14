using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Tier.BO;
using GeneralLedger.Utility;


namespace GeneralLedger.Tier.DAL
{
    public class ProductSizeDAL
    {

        public string manage(string xml, string transType)
        {
            var dbUtil = new DatabaseManager();
            //return string.Empty;
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManageProductSize";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@xmlXML", xml);
                    cmd.Parameters.AddWithValue("@blnInsert", transType.Equals("insert"));
                    cmd.Parameters.AddWithValue("@blnUpdate", transType.Equals("update"));
                    cmd.Parameters.AddWithValue("@blnDelete", transType.Equals("delete"));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return object.ReferenceEquals(reader["strProductSize"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductSize"]);
                        }
                    }
                }
            }
            return string.Empty;
        }


        public List<ProductSize> getProductSize()
        {
            var dbUtil = new DatabaseManager();
            var productSizeList = new List<ProductSize>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetProductSize";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();

             

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var productSize = new ProductSize
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            productSizeList.Add(productSize);
                        }
                        return productSizeList;
                    }
                }
            }

        }

        public List<ProductSize> getProductSizeByCriteria(string criteria)
        {
            var dbUtil = new DatabaseManager();
            var productSizeList = new List<ProductSize>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetProductSizeCriteria";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var productSize = new ProductSize
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            productSizeList.Add(productSize);
                        }
                        return productSizeList;
                    }
                }
            }

        }
    }
}
