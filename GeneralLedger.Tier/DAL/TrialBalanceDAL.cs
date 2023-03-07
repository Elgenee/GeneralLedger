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
    public class TrialBalanceDAL
    {

        public List<GLTBHdr> getGLTB(DateTime datFrom, DateTime datTo)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<GLTBHdr>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGLGetTB";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@dateFrom", datFrom);
                    cmd.Parameters.AddWithValue("@dateTo", datTo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var GLTBHdr = new GLTBHdr
                            {
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                Remarks = ReferenceEquals(reader["Remarks"], DBNull.Value) ? string.Empty : Convert.ToString(reader["Remarks"]),
                                bitLock = ReferenceEquals(reader["bitIsLock"], DBNull.Value) ? false : Convert.ToBoolean(reader["bitIsLock"])

                            };
                            glList.Add(GLTBHdr);
                        }
                        return glList;
                    }
                }
            }
        }


        public string PostGL(string datBatch, string xremarks)
        {

            var dbUtil = new DatabaseManager();
            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spProcessTrialBalance";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@datBatchDate", datBatch);
                    cmd.Parameters.AddWithValue("@strRemarks", xremarks);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return object.ReferenceEquals(reader["intIDTBGLHeader"], DBNull.Value) ? string.Empty : Convert.ToString(reader["intIDTBGLHeader"]);
                        }
                    }
                }
            }
            return string.Empty;
        }



        public List<GLTBHdr> getGLTBById(int Id)
        {
            var dbUtil = new DatabaseManager();
            var glList = new List<GLTBHdr>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGLGetGLTBTran";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intID", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var GLTBHdr = new GLTBHdr
                            {
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
                                Remarks = ReferenceEquals(reader["Remarks"], DBNull.Value) ? string.Empty : Convert.ToString(reader["Remarks"]),

                            };
                            glList.Add(GLTBHdr);
                        }
                        return glList;
                    }
                }
            }
        }



        public List<GLTBDtl> getGLTBDetail(int intID)
        {
            var dbUtil = new DatabaseManager();
            var dtlList = new List<GLTBDtl>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGLGetTBDetail";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intIDhdr", Convert.ToInt32(intID));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //test

                            var pye = new GLTBDtl
                            {
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                intIDTBBatchHdr = ReferenceEquals(reader["intIDTBBatchHdr"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDTBBatchHdr"]),
                                curCredit = ReferenceEquals(reader["curCredit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curCredit"]),
                                curDebit = ReferenceEquals(reader["curDebit"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curDebit"]),
                                COADesc = ReferenceEquals(reader["COADesc"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COADesc"]),
                                COASubDesc = ReferenceEquals(reader["COASubDesc"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COASubDesc"]),
                                curBegBal = ReferenceEquals(reader["curBegBal"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curBegBal"]),
                                curEndBal = ReferenceEquals(reader["curEndBal"], DBNull.Value) ? 0 : Convert.ToDecimal(reader["curEndBal"]),
                                COA = ReferenceEquals(reader["COA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["COA"]),
                                COASub = ReferenceEquals(reader["COASub"], DBNull.Value) ? 0 : Convert.ToInt32(reader["COASub"]),
                                COAstrCode = ReferenceEquals(reader["COAstrCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["COAstrCode"]),
                            };
                            dtlList.Add(pye);
                        }
                        return dtlList;
                    }
                }
            }
        }

        //public List<GLTranDetail> getGLTranDetail(int Id)
        //{
        //    var dbUtil = new DatabaseManager();
        //    var glListDetail = new List<GLTranDetail>();


        //    using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "spGLGetTBDetail";
        //            cmd.CommandTimeout = 180;
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@intID", Id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {

        //                    var GLTBHdr = new GLTBHdr
        //                    {
        //                        ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
        //                        datBatchDate = ReferenceEquals(reader["datBatchDate"], DBNull.Value) ? string.Empty : Convert.ToString(reader["datBatchDate"]),
        //                        Remarks = ReferenceEquals(reader["Remarks"], DBNull.Value) ? string.Empty : Convert.ToString(reader["Remarks"]),

        //                    };
        //                    glList.Add(GLTBHdr);
        //                }
        //                return glList;
        //            }
        //        }
        //    }
        //}

    }
}
