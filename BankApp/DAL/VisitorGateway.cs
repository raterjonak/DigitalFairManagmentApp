using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalFairApp.Model;

namespace DigitalFairApp.DAL
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
       public List<Visitor> GetVisitorsListByZoneName(string name)
       {
           int id =GetZoneIdByName(name);

           List<Visitor> visitors = new List<Visitor>();

           SqlConnection connection = new SqlConnection(connectionString);


           string query = "SELECT tbl_Visitor.v_Name,tbl_Visitor.v_Email,tbl_Visitor.v_ContactNo FROM tbl_Visitor JOIN  tbl_Visit ON tbl_Visitor.v_Id=tbl_Visit.visitor_Id  WHERE tbl_Visit.zone_Id='" + id + "'";
           // string query="SELECT tbl_Visitor.v_Name,tbl_Visitor.v_Email,tbl_Visitor.v_ContactNo FROM tbl_Visitor JOIN  tbl_Visit ON tbl_Visitor.v_Id=tbl_Visit.visitor_Id JOIN tbl_Zone ON tbl_Visit.zone_Id=tbl_Zone.z_Id WHERE tbl_Zone.z_Id='"+id+"'";

           SqlCommand command = new SqlCommand(query, connection);

           connection.Open();

           SqlDataReader reader = command.ExecuteReader();

           while (reader.Read())
           {
               Visitor visitor = new Visitor();

               visitor.Name = reader[0].ToString();
               visitor.Email = reader[1].ToString();
               visitor.ContactNo = reader[2].ToString();
               //MessageBox.Show(visitor.Name);

               visitors.Add(visitor);


           }
           reader.Close();
           connection.Close();

           return visitors;
       }
    }
}
