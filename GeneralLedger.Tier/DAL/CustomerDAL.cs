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
    public class CustomerDAL
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
                    cmd.CommandText = "spManageCustomer";
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
                            return object.ReferenceEquals(reader["strCustomer"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCustomer"]);
                        }
                    }
                }
            }
            return string.Empty;
        }


        public List<Customer> getCustomer(string criteria)
        {
            var dbUtil = new DatabaseManager();
            var customerList = new List<Customer>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetCustomer";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var customer = new Customer
                            {


                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                                StartingDebit = ReferenceEquals(reader["curStartingDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curStartingDebit"]),
                                Debit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                Credit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                CreditLimit = ReferenceEquals(reader["curCreditLimit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCreditLimit"]),
                                Terms = ReferenceEquals(reader["intTerms"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intTerms"]),
                                PriceType = new PriceType {
                                    ID = ReferenceEquals(reader["PriceTypeID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["PriceTypeID"]),
                                    Name = ReferenceEquals(reader["PriceType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["PriceType"])
                                },
                                Address = ReferenceEquals(reader["strAddress"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAddress"]),
                                Contact = ReferenceEquals(reader["strContact"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strContact"])

                            };
                            customerList.Add(customer);
                        }
                        return customerList;
                    }
                }

            }

        }
    }
}
