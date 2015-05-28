using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Model;

namespace BankApp.DAL
{
   public class VisitorGateway
    {
       private string connectionString = ConfigurationManager.ConnectionStrings["DigitalFairConString"].ConnectionString;

       List<int> SelectedZoneIdList =new List<int>();

       public void SetAllSelectedZoneId(List<string> selectedNameList)
       {
           foreach (string name in selectedNameList)
           {
               int id = GetZoneIdByName(name);
               SelectedZoneIdList.Add(id);
           }
       }
       int GetZoneIdByName(string zoneName)
       {
           int zoneId = 0;
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT z_Id FROM tbl_Zone WHERE z_TypeName='" + zoneName + "'";

           SqlCommand command = new SqlCommand(query, connection);

           connection.Open();

           SqlDataReader reader = command.ExecuteReader();

           while (reader.Read())
           {
               zoneId += int.Parse(reader["z_Id"].ToString());

           }


           reader.Close();
           connection.Close();
           return zoneId;

       }

       public int Save(Visitor visitor)
       {

           SqlConnection connection = new SqlConnection(connectionString);

           string query = string.Format("INSERT INTO tbl_Visitor OUTPUT INSERTED.v_Id VALUES('{0}','{1}','{2}')", visitor.Name, visitor.Email, visitor.ContactNo);



           SqlCommand command = new SqlCommand(query, connection);

           connection.Open();

           // int rowsAffected = command.ExecuteNonQuery();

           int vid = (int)command.ExecuteScalar();

           connection.Close();
           // MessageBox.Show(vid.ToString());
           int increment = 1;
           connection.Open();
           foreach (int id in SelectedZoneIdList)
           {


               string query1 = string.Format("INSERT INTO tbl_Visit VALUES('{0}','{1}')", vid, id);

               string query2 = "UPDATE tbl_Zone SET z_NoOfVisitors+=1 WHERE z_id='" + id + "'";

               SqlCommand command1 = new SqlCommand(query1, connection);
               SqlCommand command2 = new SqlCommand(query2, connection);
               command1.ExecuteNonQuery();
               command2.ExecuteNonQuery();

           }
           connection.Close();
           return vid;

       }
    }
}
