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

        public List<rptJournalProoflist> getSalesEntryProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptJournalProoflistList = new List<rptJournalProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTSalesProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptJournalProoflist = new rptJournalProoflist
                            {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"]),
                                strCustomer = ReferenceEquals(reader["strCustomer"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCustomer"]),
                                strProduct = ReferenceEquals(reader["strProduct"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProduct"])


                            };

                            rptJournalProoflistList.Add(rptJournalProoflist);
                        }
                        return rptJournalProoflistList;
                    }
                }
            }
        }

        public List<rptPurchaseProoflist> getPurchaseProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptPurchaseProoflistList = new List<rptPurchaseProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTPurchaseProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptPurchaseProoflist = new rptPurchaseProoflist
                            {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"]),
                                strSupplier = ReferenceEquals(reader["strSupplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strSupplier"]),
                                strProduct = ReferenceEquals(reader["strProduct"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProduct"])


                            };

                            rptPurchaseProoflistList.Add(rptPurchaseProoflist);
                        }
                        return rptPurchaseProoflistList;
                    }
                }
            }


        }


        public List<rptInventoryProoflist> getInventoryProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptInventoryProoflistList = new List<rptInventoryProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTInventoryProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptInventoryProoflist = new rptInventoryProoflist
                            {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                TransactionType = ReferenceEquals(reader["TransactionType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["TransactionType"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"]),
                                strSupplier = ReferenceEquals(reader["strSupplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strSupplier"]),
                                strProduct = ReferenceEquals(reader["strProduct"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProduct"])


                            };

                            rptInventoryProoflistList.Add(rptInventoryProoflist);
                        }
                        return rptInventoryProoflistList;
                    }
                }
            }
        }

        public List<rptInventoryMonthlyOutstandingSummary> getInventoryMonthlyOutstandingSummary(DateTime monthDate)
        {
            var dbUtil = new DatabaseManager();
            var summaryList = new List<rptInventoryMonthlyOutstandingSummary>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInventoryMonthlyOutstandingSummary";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MonthDate", monthDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var summary = new rptInventoryMonthlyOutstandingSummary
                            {
                                ProductId = ReferenceEquals(reader["ProductId"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductId"]),
                                strProductName = ReferenceEquals(reader["strProductName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strProductName"]),
                                OpeningQty = ReferenceEquals(reader["OpeningQty"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["OpeningQty"]),
                                QtyInMonth = ReferenceEquals(reader["QtyInMonth"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["QtyInMonth"]),
                                QtyOutMonth = ReferenceEquals(reader["QtyOutMonth"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["QtyOutMonth"]),
                                ClosingQty = ReferenceEquals(reader["ClosingQty"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["ClosingQty"]),
                                UnitPrice = ReferenceEquals(reader["UnitPrice"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["UnitPrice"]),
                                OutstandingBalance = ReferenceEquals(reader["OutstandingBalance"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["OutstandingBalance"])
                            };
                            summaryList.Add(summary);
                        }
                        return summaryList;
                    }
                }
            }
        }


        public List<rptJournalProoflist> getCollectionEntryProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptJournalProoflistList = new List<rptJournalProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTCollectionProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptJournalProoflist = new rptJournalProoflist
                            {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"]),
                                strCustomer = ReferenceEquals(reader["strCustomer"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCustomer"]),

                            };

                            rptJournalProoflistList.Add(rptJournalProoflist);
                        }
                        return rptJournalProoflistList;
                    }
                }
            }
        }


        public List<rptPaymentProoflist> getPaymentProoflist(string datDateFrom, string datDateTo)
        {
            var dbUtil = new DatabaseManager();
            var rptPaymentProoflistList = new List<rptPaymentProoflist>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRPTPaymentProoflist";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datDateFrom", datDateFrom);
                    cmd.Parameters.AddWithValue("@datDateTo", datDateTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptPaymentProoflist = new rptPaymentProoflist
                            {
                                strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASub"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                                strBookType = ReferenceEquals(reader["strBookType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strBookType"]),
                                strSupplier = ReferenceEquals(reader["strSupplier"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strSupplier"]),
                            };

                            rptPaymentProoflistList.Add(rptPaymentProoflist);
                        }
                        return rptPaymentProoflistList;
                    }
                }
            }
        }

        public List<rptGetSummaryOfAccountsReceivablesSales> getSummaryOfAccountsReceivablesSales(string datDateAsOf)
        {
            var dbUtil = new DatabaseManager();
            var rptGetSummaryOfAccountsReceivablesSalesList = new List<rptGetSummaryOfAccountsReceivablesSales>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSummaryOfAccountsReceivablesSales";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datAsOfDate", datDateAsOf);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptGetSummaryOfAccountsReceivablesSales = new rptGetSummaryOfAccountsReceivablesSales
                            {
                                customerName = ReferenceEquals(reader["customerName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["customerName"]),
                                TransactionDate = ReferenceEquals(reader["TransactionDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["TransactionDate"]),
                                TRANo = ReferenceEquals(reader["TRANo"], DBNull.Value) ? string.Empty : Convert.ToString(reader["TRANo"]),
                                agentName = ReferenceEquals(reader["agentName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["agentName"]),
                                Total = ReferenceEquals(reader["Total"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["Total"]),
                                datAsOfDate = ReferenceEquals(reader["datAsOfDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datAsOfDate"])

                            };

                            rptGetSummaryOfAccountsReceivablesSalesList.Add(rptGetSummaryOfAccountsReceivablesSales);
                        }
                        return rptGetSummaryOfAccountsReceivablesSalesList;
                    }
                }
            }
        }

        public List<rptGetCustomerLedgerOverall> getCustomerLedgerOverall(int customerId)
        {
            var dbUtil = new DatabaseManager();
            var rptGetCustomerLedgerOverallList = new List<rptGetCustomerLedgerOverall>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetCustomerLedgerOverall";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptGetCustomerLedgerOverall = new rptGetCustomerLedgerOverall
                            {
                                strType = ReferenceEquals(reader["strType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strType"]),
                                strTransactionNo = ReferenceEquals(reader["strTransactionNo"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNo"]),
                                datDateTransaction = ReferenceEquals(reader["datDateTransaction"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datDateTransaction"]),
                                curTotalAmountDebit = ReferenceEquals(reader["curTotalAmountDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curTotalAmountDebit"]),
                                curTotalAmountCredit = ReferenceEquals(reader["curTotalAmountCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curTotalAmountCredit"]),
                                curRunningBalance = ReferenceEquals(reader["curRunningBalance"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curRunningBalance"])
                            };

                            rptGetCustomerLedgerOverallList.Add(rptGetCustomerLedgerOverall);
                        }
                        return rptGetCustomerLedgerOverallList;
                    }
                }
            }
        }


        public List<rptGetSupplierLedgerOverall> getSupplierLedgerOverall(int supplierID)
        {
            var dbUtil = new DatabaseManager();
            var rptGetSupplierLedgerOverallList = new List<rptGetSupplierLedgerOverall>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSupplierLedgerOverall";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rptGetCustomerLedgerOverall = new rptGetSupplierLedgerOverall
                            {
                                strType = ReferenceEquals(reader["strType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strType"]),
                                strTransactionNo = ReferenceEquals(reader["strTransactionNo"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNo"]),
                                datDateTransaction = ReferenceEquals(reader["datDateTransaction"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datDateTransaction"]),
                                curTotalAmountDebit = ReferenceEquals(reader["curTotalAmountDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curTotalAmountDebit"]),
                                curTotalAmountCredit = ReferenceEquals(reader["curTotalAmountCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curTotalAmountCredit"]),
                                curRunningBalance = ReferenceEquals(reader["curRunningBalance"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curRunningBalance"])
                            };

                            rptGetSupplierLedgerOverallList.Add(rptGetCustomerLedgerOverall);
                        }
                        return rptGetSupplierLedgerOverallList;
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
