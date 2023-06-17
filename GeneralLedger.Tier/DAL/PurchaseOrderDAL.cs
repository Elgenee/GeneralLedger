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
    public class PurchaseOrderDAL
    {
        public List<Product> getProductSearch(string criteria , int ProductCategoryID , int ProductBrandID , int ProductTypesID)
        {

            var dbUtil = new DatabaseManager();
            var ProductList = new List<Product>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spPurchaseOrderProductSearch";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);
                    cmd.Parameters.AddWithValue("@intProductCategoryID", ProductCategoryID);
                    cmd.Parameters.AddWithValue("@intProductBrandID", ProductBrandID);
                    cmd.Parameters.AddWithValue("@intProductTypesID", ProductTypesID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var product = new Product
                            {
                            
                                ProductName = ReferenceEquals(reader["strProductName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductName"]),
                                ProductDetails = new List<SearchProductAndColorAndSize>() {
                                    new SearchProductAndColorAndSize {
                                         ID = ReferenceEquals(reader["Id"], DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                                         ProductColor = new ProductColor {
                                             ID = ReferenceEquals(reader["ProductColorID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductColorID"]),
                                             Name = ReferenceEquals(reader["ProductColor"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductColor"])
                                         },
                                         ProductSize = new ProductSize {
                                             ID = ReferenceEquals(reader["ProductSizeID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductSizeID"]),
                                             Name = ReferenceEquals(reader["ProductSize"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductSize"])
                                         },
                                         CurStock =  ReferenceEquals(reader["curStock"], DBNull.Value) ? 0 : Convert.ToInt32(reader["curStock"]),
                                         //Cost =  ReferenceEquals(reader["curCost"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCost"]),
                                         ActStock =  ReferenceEquals(reader["actStock"], DBNull.Value) ? 0 : Convert.ToInt32(reader["actStock"]),
                                    }
                                },
                                ProductCategory = new ProductCategory
                                {
                                    ID = ReferenceEquals(reader["ProductCategoryID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductCategoryID"]),
                                    Name = ReferenceEquals(reader["ProductCategory"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductCategory"]),
                                },
                                ProductType = new ProductType
                                {
                                    ID = ReferenceEquals(reader["ProductTypeID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductTypeID"]),
                                    Name = ReferenceEquals(reader["ProductType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductType"]),
                                },
                                ProductBrand = new ProductBrand
                                {
                                    ID = ReferenceEquals(reader["ProductBrandID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductBrandID"]),
                                    Name = ReferenceEquals(reader["ProductBrand"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductBrand"]),
                                },
                                

                            };

                            ProductList.Add(product);
                        }
                        return ProductList;
                    }
                }
            }

        }



        public List<PurchaseOrder> spGetPurchaseOrderForApproval() {
            var dbUtil = new DatabaseManager();
            var PurchaseOrderList = new List<PurchaseOrder>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetPurchaseOrderForApproval";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var purchaseOrder = new PurchaseOrder {
                                ID = ReferenceEquals(reader["Id"], DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                                PONumber = ReferenceEquals(reader["strPONumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strPONumber"]),
                                DatePurchased = ReferenceEquals(reader["datDatePurchased"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datDatePurchased"]),
                                Supplier = new Supplier {
                                     Name = ReferenceEquals(reader["supplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["supplier"]),
                                },
                                Location = new Location {
                                    Name = ReferenceEquals(reader["location"], DBNull.Value) ? string.Empty : Convert.ToString(reader["location"]),
                                },
                                GrandTotal = ReferenceEquals(reader["curGrandTotal"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curGrandTotal"])
                            };

                            PurchaseOrderList.Add(purchaseOrder);
                        }
                        return PurchaseOrderList;
                    }
                }
            }
        }

        public List<PurchaseOrder> spGetPurchaseOrderForPending()
        {
            var dbUtil = new DatabaseManager();
            var PurchaseOrderList = new List<PurchaseOrder>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetPurchaseOrderForPending";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var purchaseOrder = new PurchaseOrder
                            {
                                ID = ReferenceEquals(reader["Id"], DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                                PONumber = ReferenceEquals(reader["strPONumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strPONumber"]),
                                DatePurchased = ReferenceEquals(reader["datDatePurchased"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datDatePurchased"]),
                                Supplier = new Supplier
                                {
                                    Name = ReferenceEquals(reader["supplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["supplier"]),
                                },
                                Location = new Location
                                {
                                    Name = ReferenceEquals(reader["location"], DBNull.Value) ? string.Empty : Convert.ToString(reader["location"]),
                                },
                                GrandTotal = ReferenceEquals(reader["curGrandTotal"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curGrandTotal"]),
                                TotalQuantity = ReferenceEquals(reader["curTotalQty"], DBNull.Value) ? 0 : Convert.ToInt32(reader["curTotalQty"]),
                                TotalReceived = ReferenceEquals(reader["curTotalReceived"], DBNull.Value) ? 0 : Convert.ToInt32(reader["curTotalReceived"])
                                
                            };

                            PurchaseOrderList.Add(purchaseOrder);
                        }
                        return PurchaseOrderList;
                    }
                }
            }
        }


        public string manage(string xml, string transType)
        {
            var dbUtil = new DatabaseManager();
            return string.Empty;
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManagePurchaseOrder";
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
                            return object.ReferenceEquals(reader["intIDPurchaseOrder"], DBNull.Value) ? string.Empty : Convert.ToString(reader["intIDPurchaseOrder"]);
                        }
                    }
                }
            }
            return string.Empty;
        }


        public string spManageApprovePurchaseOrder(int intIDPO, string transType , int userID) {

            var dbUtil = new DatabaseManager();
            //return string.Empty;
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManageApprovePurchaseOrder";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intIDPO", @intIDPO);
                    cmd.Parameters.AddWithValue("@blnUpdate", transType.Equals("update"));
                    cmd.Parameters.AddWithValue("@blnCancel", transType.Equals("cancel"));
                    cmd.Parameters.AddWithValue("@intIDUser", userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return object.ReferenceEquals(reader["intIDPurchaseOrder"], DBNull.Value) ? string.Empty : Convert.ToString(reader["intIDPurchaseOrder"]);
                        }
                    }
                }
            }
            return string.Empty;
        }

    }
}
