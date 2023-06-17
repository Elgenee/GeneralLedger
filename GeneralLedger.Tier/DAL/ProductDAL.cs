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
    public class ProductDAL
    {

        public List<ProductCharacteristic> getProductCharacteristic()
        {
            var dbUtil = new DatabaseManager();
            var productCharacteristicList = new List<ProductCharacteristic>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetProductCharacteristic";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var productCharacteristic = new ProductCharacteristic
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            productCharacteristicList.Add(productCharacteristic);
                        }
                        return productCharacteristicList;
                    }
                }
            }

        }


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
                    cmd.CommandText = "spManageProduct";
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
                            return object.ReferenceEquals(reader["strProduct"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProduct"]);
                        }
                    }
                }
            }
            return string.Empty;
        }



        public string ManageProductDetail(string xml, string transType)
        {
            var dbUtil = new DatabaseManager();
            //return string.Empty;
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManageProductDetails";
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
                            return object.ReferenceEquals(reader["strProductDetails"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductDetails"]);
                        }
                    }
                }
            }
            return string.Empty;
        }



        public List<Location> getLocation()
        {

            var dbUtil = new DatabaseManager();
            var LocationList = new List<Location>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetLocation";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Location = new Location
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            LocationList.Add(Location);
                        }
                        return LocationList;
                    }
                }
            }

        }



        public List<Product> getProductSearch(string criteria)
        {

            var dbUtil = new DatabaseManager();
            var ProductList = new List<Product>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spProductSearch";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var product = new Product {
                                ID = ReferenceEquals(reader["Id"], DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                                ProductName = ReferenceEquals(reader["strProductName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductName"]),
                                Description = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                PerPieceBox = ReferenceEquals(reader["intPerPiecePerBox"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["intPerPiecePerBox"]),
                                ProductCharacteristic = new ProductCharacteristic {
                                    ID = ReferenceEquals(reader["ProductCharacteristicID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductCharacteristicID"]),
                                    Name = ReferenceEquals(reader["ProductCharacteristic"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductCharacteristic"]),

                                },
                                ProductCategory = new ProductCategory {
                                    ID = ReferenceEquals(reader["ProductCategoryID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductCategoryID"]),
                                    Name = ReferenceEquals(reader["ProductCategory"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductCategory"]),
                                },
                                ProductType = new ProductType {
                                    ID = ReferenceEquals(reader["ProductTypeID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductTypeID"]),
                                    Name = ReferenceEquals(reader["ProductType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductType"]),
                                },
                                ProductBrand = new ProductBrand {
                                    ID = ReferenceEquals(reader["ProductBrandID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductBrandID"]),
                                    Name = ReferenceEquals(reader["ProductBrand"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductBrand"]),
                                },
                                Location = new Location {
                                    ID = ReferenceEquals(reader["LocationID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["LocationID"]),
                                    Name = ReferenceEquals(reader["Location"], DBNull.Value) ? string.Empty : Convert.ToString(reader["Location"]),
                                }
                            };


                            ProductList.Add(product);
                        }
                        return ProductList;
                    }
                }
            }

        }


        public List<SearchProductAndColorAndSize> getProductDetails(int ProductID)
        {

            var dbUtil = new DatabaseManager();
            var SearchProductAndColorAndSizeList = new List<SearchProductAndColorAndSize>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGETProductDetailsByProductID";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intProductID", ProductID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var SearchProductAndColorAndSize = new SearchProductAndColorAndSize
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                ProductColorID = ReferenceEquals(reader["intIDProductColor"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDProductColor"]),
                                ProductColor = new ProductColor {
                                    ID = ReferenceEquals(reader["intIDProductColor"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDProductColor"]),
                                    Name = ReferenceEquals(reader["ProductColor"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductColor"]),

                                },
                                ProductSizeID = ReferenceEquals(reader["intIDProductSize"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDProductSize"]),
                                ProductSize  = new ProductSize {
                                     ID = ReferenceEquals(reader["intIDProductSize"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDProductSize"]),
                                     Name = ReferenceEquals(reader["ProductSize"], DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductSize"]),
                                },
                                Mininum = ReferenceEquals(reader["intMininum"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intMininum"]),
                                Length = ReferenceEquals(reader["intLength"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intLength"]),
                                Width = ReferenceEquals(reader["intWidth"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intWidth"]),
                                Height = ReferenceEquals(reader["intHeight"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intHeight"]),
                              

                            };
                            SearchProductAndColorAndSizeList.Add(SearchProductAndColorAndSize);
                        }
                        return SearchProductAndColorAndSizeList;
                    }
                }
            }

        }
    }
}
