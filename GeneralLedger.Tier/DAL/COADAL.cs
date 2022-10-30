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
    public class COADAL
    {
        public List<COA> getCOA(string criteria)
        {
            var dbUtil = new DatabaseManager();
            var coaList = new List<COA>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOA";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCriteria", criteria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var coa = new COA
                            {
                               
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                intIDMasCOAGroup = ReferenceEquals(reader["intIDMasCOAGroup"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCOAGroup"]),
                                strAcctSide = ReferenceEquals(reader["strAcctSide"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctSide"]),
                                strCode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"]),
                                strName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                                strCOANameGroup = ReferenceEquals(reader["strNameGroup"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strNameGroup"]),
                                strAcctType = ReferenceEquals(reader["strAcctType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctType"]),
                                ISOrdering =  ReferenceEquals(reader["intIncomeStatementOrderby"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIncomeStatementOrderby"])
                            };
                            coaList.Add(coa);
                        }
                        return coaList;
                    }
                }

            }

        }

        public COA getCOAbyCode(string strCOACode)
        {
            var dbUtil = new DatabaseManager();

            var coac = new COA();
           
            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOAbyCode";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@strCOACode", strCOACode);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        coac.ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]);
                        coac.strName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]);
                        coac.intIDMasCOAGroup = ReferenceEquals(reader["intIDMasCOAGroup"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCOAGroup"]);
                        coac.strAcctSide = ReferenceEquals(reader["strAcctSide"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctSide"]);
                        coac.strAcctType = ReferenceEquals(reader["strAcctType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctType"]);
                     }
                     
                    return coac;
                 }
             }
        }

        public COASub getCOASubByCode(int intIDCOA, string strCOASubCode)
        {
            var dbUtil = new DatabaseManager();

            var coas = new COASub();

            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOASubByCode";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intCOACode", intIDCOA);
                    cmd.Parameters.AddWithValue("@strCOASub", strCOASubCode);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        coas.ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]);
                        coas.strCoaSubName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]);
                        
                    }

                    return coas;
                }
            }
        }

        public List<COA> GetByCOAId(int id)
        {
            //var COARow = new DataRow();

            var dbUtil = new DatabaseManager();
            var coalist = new List<COA>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOARecord";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@intID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Something is very wrong");

                        var coa = new COA
                        {
                         ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                         intIDMasCOAGroup = ReferenceEquals(reader["intIDMasCOAGroup"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCOAGroup"]),
                         strAcctSide = ReferenceEquals(reader["strAcctSide"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctSide"]),
                         strCode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"]),
                         strName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                         strAcctType = ReferenceEquals(reader["strAcctType"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strAcctType"])
                        };

                        coalist.Add(coa);
                        return coalist;
                        
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
                    cmd.CommandText = "spMasManageCOA";
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
                            return object.ReferenceEquals(reader["strCoaCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCoaCode"]);
                        }
                    }

                }
            }
            return string.Empty;

        }

        public string managesub(string xml, string transType)
        {

            var dbUtil = new DatabaseManager();

            using (SqlConnection conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasManageCOASub";
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
                            return object.ReferenceEquals(reader["strCoaCodeSub"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCoaCodeSub"]);
                        }
                    }

                }
            }
            return string.Empty;

        }



        public List<COAGroup> getGroupType()
        {

            var dbUtil = new DatabaseManager();
            var coaGroupList = new List<COAGroup>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOAGroup";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var coagroup = new COAGroup
                            {
                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                strName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };

                            coaGroupList.Add(coagroup);
                        }
                        return coaGroupList;
                    }
                }

            }

        }


        public List<COASub> getCOAsub(int coaid)
        {
            var dbUtil = new DatabaseManager();
            var coaList = new List<COASub>();


            using (var conn = new SqlConnection(dbUtil.getSQLConnectionString("MainDB")))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spMasGetCOASub";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idCOA", coaid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var coa = new COASub
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                intIDCOA = ReferenceEquals(reader["intIDMasCOA"], DBNull.Value) ? 0 : Convert.ToInt32(reader["intIDMasCOA"]),
                                strCoaSubCode = ReferenceEquals(reader["strCode"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strCode"]),
                                strCoaSubName = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"]),
                              };
                            coaList.Add(coa);
                        }
                        return coaList;
                    }
                }

            }

        }


    }
}
