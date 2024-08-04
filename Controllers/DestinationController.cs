using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.DTOs.MeetingDTO;
using dotnet_webapi_ef.Mapper;
using dotnet_webapi_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DestinationController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDesAll()
        {
            var Destination = _context.Destinations.Select(d => d.toDesinationDio());
            return Ok(Destination);
        }

        [HttpGet("{id}")]
        public IActionResult GetDesbyID([FromRoute] int id)
        {
            var Destination = _context.Destinations.Find(id);
            if (Destination == null)
            {
                return NotFound();
            }
            return Ok(Destination.toDesinationDio());
        }

        [HttpGet("zone/{zone}")]
        public IActionResult GetDesbyZone([FromRoute] String zone)
        {
            var Destination = _context.Destinations.Where(d => d.Zone.Contains(zone)).Select(d => d.toDesinationDio());
            if (Destination == null)
            {
                return NotFound();
            }
            return Ok(Destination);
        }
    }
}