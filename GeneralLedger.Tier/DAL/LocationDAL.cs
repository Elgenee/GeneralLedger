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
    public class LocationDAL
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
                    cmd.CommandText = "spManageLocation";
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
                            return object.ReferenceEquals(reader["strLocation"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strLocation"]);
                        }
                    }
                }
            }
            return string.Empty;
        }

        public List<Location> getLocation()
        {
            var dbUtil = new DatabaseManager();
            var locationList = new List<Location>();


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

                            var location = new Location
                            {

                                ID = ReferenceEquals(reader["ID"], DBNull.Value) ? 0 : Convert.ToInt32(reader["ID"]),
                                Name = ReferenceEquals(reader["strName"], DBNull.Value) ? string.Empty : Convert.ToString(reader["strName"])
                            };
                            locationList.Add(location);

                        }
                        return locationList;
                    }
                }

            }

        }
    }
}
