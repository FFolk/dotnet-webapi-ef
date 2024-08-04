using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TripController(ApplicationDBContext context)
        {
            _context = context;
        }

        //GET http://localhost:5087/api/trips
              [HttpGet]
        public IActionResult GetAll()
        {
            var trips = _context.Trips.Include(t => t.Destination).Select(t => t.toTripDTO());
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public IActionResult GetTripByID([FromRoute] int id)
        {
            var trip = _context.Trips.Include(t => t.Destination).Where(t => t.Idx == id).FirstOrDefault();
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip.toTripDTO());
        }


        [HttpGet("name/{name}")]
        public IActionResult GetCusByName([FromRoute] String name)
        {
            var Trips = _context.Trips.Where(t => t.Name.Contains(name));
            return Ok(Trips);
        }

    }
}