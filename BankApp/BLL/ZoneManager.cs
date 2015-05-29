using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalFairApp.DAL;
using DigitalFairApp.Model;

namespace DigitalFairApp.BLL
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

        public List<Zone> GetZonesByName(string zoneName)
        {
            return aZoneGateway.GetZonesByName(zoneName);

        }
        public List<Zone> GetAllZones()
        {
            return aZoneGateway.GetZones();

        }



    }
}
