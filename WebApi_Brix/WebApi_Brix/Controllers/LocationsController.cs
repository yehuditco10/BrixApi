using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Brix.Models;
using WebApi_Brix.BL;
namespace WebApi_Brix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Location>>> Get()
        {
            try
            {
                Locations.LoadLocationsAsync();
                //to do async ??
                var results = await Locations.GetLocationsAsync();
                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "data failed");
                //return BadRequest("get location failed");
            }

        }

        [HttpGet("{patienId}")]
        public async Task<ActionResult<List<Location>>> Get(string patienId)
        {
            try
            {
                var results = await Locations.GetLocationsByPatientAsync(patienId);
                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "data failed");
                //return BadRequest("get location failed");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Location>>> Post(List<Location> newLocation)
        {
            try
            {
                //if i wont send patientId
                //if (id == "")
                //    id = newLocation[0].patientId;
                var results = await Locations.AddLocationsAsync(newLocation, "111");
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
