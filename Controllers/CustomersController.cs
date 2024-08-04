using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
         private readonly ApplicationDBContext _context;
        public CustomersController(ApplicationDBContext context)
        {
            _context = context;
        }

         [HttpGet]         
        public IActionResult GetCusAll(){
            var Customers = _context.Customers;
            return Ok(Customers);
        }

          [HttpGet("{id}")]         
        public IActionResult GetCusbyID([FromRoute] int id){
            var Customers = _context.Customers.Find(id);
            if(Customers == null){
                return NotFound();
            }
            return Ok(Customers);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetCusByName([FromRoute] String name){
            var Customers = _context.Customers.Where(c => c.Fullname.Contains(name));
            return Ok(Customers);
        }
    }
}