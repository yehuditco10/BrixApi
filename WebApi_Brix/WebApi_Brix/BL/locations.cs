using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Brix.Models;

namespace WebApi_Brix.BL
{
    public class Locations
    {
        public static List<Location> locations { get; set; }
        //public Locations()
        //{
        //    locations = new List<Location>
        //    {
        //        new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"school","111"),
        //        new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"park","111"),
        //        new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"library","111"),
        //        new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"restaurant","222"),
        //    };
        //}
        public static async void LoadLocationsAsync()
        {
            try
            {
                locations = new List<Location>
            {
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"school","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"park","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"library","111"),
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"restaurant","222"),
            };
            }
            catch (Exception)
            {
                throw new Exception("load failed");
            }

        }
        public static async Task<List<Location>> GetLocationsAsync()
        {
            try
            {
                return new List<Location>
            {
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"school","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"park","111"),
                new Location("Bney Brak",new DateTime(2004, 12, 12),new DateTime(2004, 11, 12),"library","111"),
                new Location("Jerusalem",new DateTime(2005, 12, 12),new DateTime(2005, 11, 12),"restaurant","222"),
            };
            }
            catch (Exception)
            {

                throw new Exception("we didn't find");
            }

            return null;
        }

        public static async Task<List<Location>> GetLocationsByPatientAsync(String id)
        {
            try
            {
                if (locations.FirstOrDefault(l => l.patientId == id) != null)
                {
                    return locations.Where(i => i.patientId == id).ToList();
                }
            }
            catch (Exception)
            {

                throw new Exception("we didn't find");
            }

            return null;
        }
        public static async Task<List<Location>> AddLocationsAsync(List<Location> newLocations,string id)
        {
            try
            {
                //locations.RemoveAll(l => l.patientId == id);
                locations.AddRange(newLocations);
                return newLocations;
            }
            catch (Exception)
            {

                throw new Exception("adding failed");
            }

            return null;
        }

    }
}
