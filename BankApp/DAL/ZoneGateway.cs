using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalFairApp.Model;

namespace DigitalFairApp.DAL
{

    public class ZoneGateway
    {
        private string connectionString =ConfigurationManager.ConnectionStrings["DigitalFairConString"].ConnectionString;

        public int Save(Zone zone)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "INSERT INTO [dbo].[tbl_Zone]([z_TypeName],[z_NoOfVisitors]) VALUES('" + zone.Type + "','" + zone.NumberOfVisitors + "')";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rawAffected = command.ExecuteNonQuery();
            connection.Close();
            return rawAffected;
        }

        public List<Zone> GetZones()
        {
            List<Zone> ZonesList = new List<Zone>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_Zone";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Zone zone = new Zone();

                zone.Id = int.Parse(reader["z_Id"].ToString());
                zone.Type = reader["z_TypeName"].ToString();
                zone.NumberOfVisitors = int.Parse(reader["z_NoOfVisitors"].ToString());

                ZonesList.Add(zone);

            }


            reader.Close();
            connection.Close();
            return ZonesList;

        }

        public List<Zone> GetZonesByName(string zoneName)
        {
            List<Zone> ZonesList = new List<Zone>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_Zone WHERE z_TypeName='"+zoneName+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Zone zone = new Zone();

                zone.Id = int.Parse(reader["z_Id"].ToString());
                zone.Type = reader["z_TypeName"].ToString();
                zone.NumberOfVisitors = int.Parse(reader["z_NoOfVisitors"].ToString());

                ZonesList.Add(zone);

            }


            reader.Close();
            connection.Close();
            return ZonesList;

        }

    }
}
