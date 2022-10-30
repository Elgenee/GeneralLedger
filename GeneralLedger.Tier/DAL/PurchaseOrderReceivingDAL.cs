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
    public class PurchaseOrderReceivingDAL
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
                    cmd.CommandText = "spManagePurchaseOrderReceiving";
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
                            return object.ReferenceEquals(reader["intIDPurchaseOrderReceiving"], DBNull.Value) ? string.Empty : Convert.ToString(reader["intIDPurchaseOrderReceiving"]);
                        }
                    }
                }
            }
            return string.Empty;
        }

        public List<PurchaseOrderReceivingStatusDetails> GetPurchaseOrderReceivingStatusDetails(int PurchaseOrderID) {

            var dbUtil = new DatabaseManager();
            var PurchaseOrderReceivingStatusDetailsList = new List<PurchaseOrderReceivingStatusDetails>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetPurchaseOrderReceivingProducts";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intPurchaseOrderID", PurchaseOrderID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var purchaseOrderReceivingStatusDetails = new PurchaseOrderReceivingStatusDetails
                            {
                                
                                PurchaseOrderDetailID = ReferenceEquals(reader["purchaseOrderDetailID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["purchaseOrderDetailID"]),
                                ProductName = ReferenceEquals(reader["strProductName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductName"]),
                                ProductColor =  new ProductColor {
                                     Name = ReferenceEquals(reader["ProductColor"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductColor"]),
                                },
                                ProductSize = new ProductSize {
                                    Name = ReferenceEquals(reader["ProductSize"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductSize"]),
                                },
                                Unit = ReferenceEquals(reader["Unit"], DBNull.Value) ? string.Empty : Convert.ToString(reader["Unit"]),
                                Quantity = ReferenceEquals(reader["Quantity"], DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]),
                                QuantityReceived = ReferenceEquals(reader["QuantityReceived"], DBNull.Value) ? 0 : Convert.ToInt32(reader["QuantityReceived"]),
                                QuantityRemaining = ReferenceEquals(reader["QuantityRemaining"], DBNull.Value) ? 0 : Convert.ToInt32(reader["QuantityRemaining"]),
                                ReceivingStatus = new ReceivingStatus {
                                    ID = ReferenceEquals(reader["ReceivingStatusID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ReceivingStatusID"]),
                                    Name = ReferenceEquals(reader["ReceivingStatus"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ReceivingStatus"]),
                                }
                            };

                            PurchaseOrderReceivingStatusDetailsList.Add(purchaseOrderReceivingStatusDetails);
                        }
                        return PurchaseOrderReceivingStatusDetailsList;
                    }
                }
            }

        }
    }
}
