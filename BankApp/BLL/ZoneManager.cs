using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.DAL;
using BankApp.Model;

namespace BankApp.BLL
{
    class ZoneManager
    {
        ZoneGateway aZoneGateway=new ZoneGateway();


        public string Save(Zone zone)
        {
            if (aZoneGateway.Save(zone)>0)
            {
                return "Save Successfully.";

            }
            else
            {
                return "Fail";
            }
            

        }

        public List<Zone> GetAllZones()
        {
            return aZoneGateway.GetZones();

        }



    }
}
