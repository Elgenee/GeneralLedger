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
    public class JournalEntryDAL
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
                    cmd.CommandText = "spManageJournalEntry";
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
                            return object.ReferenceEquals(reader["strJournalEntry"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strJournalEntry"]);
                        }
                    }
                }
            }
            return string.Empty;
        }


        public List<GLTranDetail> getTranDetail(int intIDGLTranHeader)
        {
            var dbUtil = new DatabaseManager();
            var glTranDetailList = new List<GLTranDetail>();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetTranDetail";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intIDGLTranHeader", intIDGLTranHeader);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var glTranDetail = new GLTranDetail
                            {
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                intIDGLTranHeader = ReferenceEquals(reader["intIDGLTranHeader"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDGLTranHeader"]),
                                intIDCOA = ReferenceEquals(reader["intIDMasCoa"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCoa"]),
                                intIDCOASub = ReferenceEquals(reader["intIDMasCoaSub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCoaSub"]),
                                COA = new COA
                                {
                                    ID = ReferenceEquals(reader["intIDMasCoa"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCoa"]),
                                    strCode = ReferenceEquals(reader["strCodeCOA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCodeCOA"]),
                                    strName = ReferenceEquals(reader["strNameCOA"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strNameCOA"]),
                                },
                                COASub = new COASub
                                {
                                    ID = ReferenceEquals(reader["intIDMasCoaSub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCoaSub"]),
                                    strCoaSubCode = ReferenceEquals(reader["strCodeCOASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCodeCOASub"]),
                                    strCoaSubName = ReferenceEquals(reader["strNameCOASub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strNameCOASub"]),
                                },
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDouble(reader["curCredit"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDouble(reader["curDebit"]),

                            };

                            glTranDetailList.Add(glTranDetail);
                        };

                    }
                    return glTranDetailList;
                }
            }
        }

    public List<JournalEntry> getJournalEntryRecord(string criteria)
    {
        var dbUtil = new DatabaseManager();
        var jounarlEntryList = new List<JournalEntry>();

        using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
        {
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spJournalEntrySearch";
                cmd.CommandTimeout = 180;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@strCriteria", criteria);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var journalEntry = new JournalEntry
                        {
                            ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                            strTransactionNumber = ReferenceEquals(reader["strTransactionNumber"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionNumber"]),
                            datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                            strDescription = ReferenceEquals(reader["strDescription"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strDescription"]),
                            strTransactionCode = ReferenceEquals(reader["strTransactionCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strTransactionCode"]),
                            GLTranHeader = new GLTranHeader
                            {
                                ID = ReferenceEquals(reader["intIDGLHeader"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDGLHeader"]),
                                curCreditAmount = ReferenceEquals(reader["curCreditAmount"], DBNull.Value) ? 0 : Convert.ToDouble(reader["curCreditAmount"]),
                                curDebitAmount = ReferenceEquals(reader["curDebitAmount"], DBNull.Value) ? 0 : Convert.ToDouble(reader["curDebitAmount"])

                            }
                        };

                        jounarlEntryList.Add(journalEntry);

                    }
                    return jounarlEntryList;
                }
            }
        }
    }
}
}
