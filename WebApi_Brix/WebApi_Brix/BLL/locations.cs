using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Brix.Models;
using static WebApi_Brix.Models.Data;

namespace WebApi_Brix.BLL
{
    public class Locations
    {
      
        public static async Task<List<Location>> GetLocationsAsync()
        {
            try
            {
                return locations;
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
        public static async Task<List<Location>> AddLocationsAsync(string patientId, List<Location> newLocations)
        {
            try
            {
                locations.RemoveAll(l => l.patientId == patientId);
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
