using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.DAL;
using BankApp.Model;

namespace BankApp.BLL
{
  public  class VisitorManager
    {
      VisitorGateway visitorGateway=new VisitorGateway();
      public void SetSelectedZoneId(List<string> selectedNameList)
      {
         visitorGateway.SetAllSelectedZoneId(selectedNameList); 
      }
      public string Save(Visitor visitor)
      {
          if (visitor.Name == string.Empty)
          {
              return "Please Enter Visitor Name";
          }

          else if (visitor.Email == string.Empty)
          {
              return "Please Enter Visitor Email";
          }

          else if (visitor.ContactNo == string.Empty)
          {
              return "Please Enter Visitor Contact Number";
          }

          

          else
          {
              int value = visitorGateway.Save(visitor);

              if (value > 0)
              {



                  return "Visitor Information Saved Successfully";


              }

              else
              {
                  return "Save Operation Failed";
              }
          }


      }
    }
}
