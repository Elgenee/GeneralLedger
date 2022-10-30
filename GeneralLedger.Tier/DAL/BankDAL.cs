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
    public class BankDAL
    {

        public List<Currency> getCurrency()
        {
            var dbUtil = new DatabaseManager();
            var currencyList = new List<Currency>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCurrency";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var currency = new Currency
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            currencyList.Add(currency);
                        }
                        return currencyList;
                    }
                }
            }

        }

        public List<Bank> getBank(string criteria)
        {
            var dbUtil = new DatabaseManager();
            var bankList = new List<Bank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetBANK";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var bank = new Bank
                            {

                                 ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                 Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                                 AccountNo = ReferenceEquals(reader["strAccountNo"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAccountNo"]),
                                 AccountName = ReferenceEquals(reader["strAccountName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAccountName"]),
                                 Branch = ReferenceEquals(reader["strBranch"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBranch"]),
                                 StartingDebit  = ReferenceEquals(reader["curStartingDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curStartingDebit"]),
                                 Debit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                 Credit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                 Balance = ReferenceEquals(reader["curBalance"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curBalance"]),
                                 CurrencyID = ReferenceEquals(reader["intIDCurrency"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCurrency"]),

                            };
                            bankList.Add(bank);
                        }
                        return bankList;
                    }
                }

            }

        }

        public string manage(string xml, string transType)
        {
            var dbUtil = new DatabaseManager();
   
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spManageBank";
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
                            return object.ReferenceEquals(reader["strBank"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBank"]);
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
