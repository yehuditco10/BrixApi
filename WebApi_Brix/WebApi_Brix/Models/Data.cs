using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Brix.Models
{
    public static class Data
    {
        public static List<Location> locations { get; set; }

        static Data()
        {
            locations = new List<Location>
            {
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"school","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"park","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"library","111"),
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"restaurant","222"),
            };
        }

        public class Location
        {
            public string city { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public string location { get; set; }
            public string patientId { get; set; }

            public Location(string city, DateTime startDate, DateTime endDate, string location, string patientId)
            {
                this.city = city;
                this.startDate = startDate;
                this.endDate = endDate;
                this.location = location;
                this.patientId = patientId;

            }

        }
    }
}
