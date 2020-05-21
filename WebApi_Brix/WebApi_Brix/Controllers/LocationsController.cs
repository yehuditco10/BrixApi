using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Brix.Models;
using WebApi_Brix.BLL;
using Newtonsoft.Json;
using static WebApi_Brix.Models.Data;
using Microsoft.AspNetCore.Cors;

namespace WebApi_Brix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[EnableCors("MyPolicy")]
    //[EnableCors("AllowAllHeaders")]
    public class LocationsController : ControllerBase
    {

        [Route("GetByCity")]
        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetByCity(string city = null)
        {
            try
            {
                var list = await Locations.GetLocationsAsync();
                var results = new List<Location>();
                if (city != null && city != "All" && city != "")
                {
                    results = list.Where(c => c.city == city).ToList();
                    return results;
                }
                return list;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "data failed");
            }

        }
        [HttpGet("{patienId}")]
        public async Task<ActionResult<List<Location>>> Get(string patienId)
        {
            try
            {
                var results = await Locations.GetLocationsByPatientAsync(patienId);
                if (results == null || results.Count() <= 0)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "not found locations for this patient");

                }
                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "data failed");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Location>>> Post(Location[] newLocation)
        {
            try
            {
                if (newLocation.Count() <= 0)
                    return BadRequest("location is null");
                var results = await Locations.AddLocationsAsync(newLocation[0].patientId, newLocation.ToList());
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] string fname)
        //{
        //    try
        //    {
        //        return Ok(fname);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }


}
