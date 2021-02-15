using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VamosLaOnibus.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VamosLaOnibus.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        [HttpGet]
        public async Task<List<TripWithImage>> GetStart()
        {
            Business.Trips trips = new Business.Trips();
            return await trips.GetStart(2);

        }


        [HttpGet]
        public async Task<List<TripWithImage>> GetParameter([FromQuery] string date, [FromQuery] string classbuss)
        {
            Business.Trips trips = new Business.Trips();
            return await trips.GetStart(date, classbuss, "");

        }

        [HttpGet]
        public async Task<List<string>> GetBusClass()
        {
            Business.Trips trips = new Business.Trips();
            return await trips.GetBusClass();

        }

    }
}
