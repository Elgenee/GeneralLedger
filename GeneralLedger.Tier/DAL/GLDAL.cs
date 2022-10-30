using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Tier.BO;
using GeneralLedger.Utility;
using System.Data.SqlClient;

namespace GeneralLedger.Tier.DAL
{
    public class GLDAL
    {

        public List<rptISIncome> getRepISIncome(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISIncome>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISGrossSales";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                  
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISIncome
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"]),
                                intIDCOASubx = ReferenceEquals(reader["intIDCOASubx"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASubx"]),
                                strCOANamex = ReferenceEquals(reader["strCOANamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOANamex"]),
                                strCOASubNamex = ReferenceEquals(reader["strCOASubNamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubNamex"]),
                                strCOACode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"]),
                                strIncome = ReferenceEquals(reader["strIncome"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strIncome"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISLessSales> getRepISLessSales(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISLessSales>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISLessSales";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISLessSales
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"]),
                                intIDCOASubx = ReferenceEquals(reader["intIDCOASubx"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASubx"]),
                                strCOANamex = ReferenceEquals(reader["strCOANamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOANamex"]),
                                strCOASubNamex = ReferenceEquals(reader["strCOASubNamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubNamex"]),
                                strCOACode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISLessCostOfGoodSold> getRepISLessCostOfGoodSold(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISLessCostOfGoodSold>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISLessCostOfGoodSold";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISLessCostOfGoodSold
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"]),
                                intIDCOASubx = ReferenceEquals(reader["intIDCOASubx"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASubx"]),
                                strCOANamex = ReferenceEquals(reader["strCOANamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOANamex"]),
                                strCOASubNamex = ReferenceEquals(reader["strCOASubNamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubNamex"]),
                                strCOACode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptBSCashBank> getRepBSCashBank(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptBSCashBank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spBSCurrentAsset";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptBSCashBank
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptBSCashBank> getRepBSFixedAsset(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptBSCashBank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spBSFixedAsset";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptBSCashBank
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }

        public List<rptBSCashBank> getRepBSOtherAsset(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptBSCashBank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spOtherAsset";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptBSCashBank
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptBSCashBank> getRepBSLiabilityAccountsPayable(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptBSCashBank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spLiabilityAccountsPayable";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptBSCashBank
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }

        public List<rptBSCashBank> getRepBSOwnersEquity(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptBSCashBank>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spOwnersEquity";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptBSCashBank
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }

        public List<rptFATransportationEquipment> getRepFATransportationEquipment(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptFATransportationEquipment>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spFATransportationEquipment";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptFATransportationEquipment
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptOtherAsset> getRepOtherAsset(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptOtherAsset>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spOtherAsset";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptOtherAsset
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }



        public List<rptFALessACCUMDEPN> getRepFALessACCUMDEPN(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptFALessACCUMDEPN>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spFALessACCUMDEPN";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptFALessACCUMDEPN
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                intIDCOASub = ReferenceEquals(reader["intIDCOASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASub"]),
                                strCOAName = ReferenceEquals(reader["strCOAName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOAName"]),
                                strCOASubName = ReferenceEquals(reader["strCOASubName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubName"]),

                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }

        public List<rptJournalProoflist> getJournalEntryProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptJournalProoflistList = new List<rptJournalProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTJournalProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptJournalProoflist = new rptJournalProoflist {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                 COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                 COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"])

                            };

                            rptJournalProoflistList.Add(rptJournalProoflist);
                        }
                        return rptJournalProoflistList;
                    }
                }
            }
        }

        public List<rptISExpenses> getRepISExpense(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISExpenses>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISExpense";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISExpenses
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                intIDCOA = ReferenceEquals(reader["intIDCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOA"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"]),
                                intIDCOASubx = ReferenceEquals(reader["intIDCOASubx"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDCOASubx"]),
                                strCOANamex = ReferenceEquals(reader["strCOANamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOANamex"]),
                                strCOASubNamex = ReferenceEquals(reader["strCOASubNamex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCOASubNamex"]),
                                strCode = ReferenceEquals(reader["strCodex"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCodex"]),
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }

        public List<rptISTotal> getRepISTotal(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISTotal>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISTotal";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISTotal
                            {
                                curTotalAmt = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISProvisionIT> getRepISProvIT(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISProvisionIT>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISProvIT";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISProvisionIT
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISNetIncome> getRepISNetIncome(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISNetIncome>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISNetIncome";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISNetIncome
                            {
                                curTotalAmt = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISNetSalesTotal> getRepISNetSalesTotal(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISNetSalesTotal>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISNetSalesTotal";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISNetSalesTotal
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }


        public List<rptISNetSalesTotal> getRepISLessCostOfGoodSoldTotal(int intFiscalYear, int intMonth)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<rptISNetSalesTotal>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "rptISLessCostOfGoodSoldTotal";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intFiscalYear", intFiscalYear);
                    cmd.Parameters.AddWithValue("@intMonth", intMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var pye = new rptISNetSalesTotal
                            {
                                curAmount = ReferenceEquals(reader["curAmount"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curAmount"]),
                                strMonth = ReferenceEquals(reader["strMonth"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strMonth"])
                            };
                            glList.Add(pye);
                        }
                        return glList;
                    }
                }
            }
        }
    }
}
