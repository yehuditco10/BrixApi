using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Brix.Models
{
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
