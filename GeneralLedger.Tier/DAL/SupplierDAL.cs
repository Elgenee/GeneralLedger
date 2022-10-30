using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeneralLedger.Tier.BO;
using GeneralLedger.Utility;
namespace GeneralLedger.Tier.DAL
{
    public class SupplierDAL
    {

        public string manage(string xml, string transType)
        {
            var dbUtil = new DatabaseManager();

            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManageSupplier";
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
                            return object.ReferenceEquals(reader["strSupplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strSupplier"]);
                        }
                    }
                }
            }
            return string.Empty;
        }

        public List<Supplier> getSupplier(string criteria)
        {
            var dbUtil = new DatabaseManager();
            var supplierList = new List<Supplier>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSupplier";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var supplier = new Supplier
                            {


                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                                StartingDebit = ReferenceEquals(reader["curStartingDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curStartingDebit"]),
                                Debit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                Credit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                Balance = ReferenceEquals(reader["curBalance"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curBalance"]),
                                Bank = new Bank {
                                     ID = ReferenceEquals(reader["bankID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["bankID"]),
                                     AccountName = ReferenceEquals(reader["bank"], DBNull.Value) ? string.Empty : Convert.ToString(reader["bank"]),
                                },
                                Address = ReferenceEquals(reader["strAddress"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAddress"]),
                                Contacts = ReferenceEquals(reader["strContacts"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strContacts"])
                                 

                            };
                            supplierList.Add(supplier);
                        }
                        return supplierList;
                    }
                }

            }

        }



    }
}
