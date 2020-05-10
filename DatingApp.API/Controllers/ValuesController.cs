using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{   //HA# http:localhost:5000/api/values route
    [Route("api/[controller]")]
    [ApiController]
    //HA# ValuesController is really api/values. The 'Controller' part acn be ignored 
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values #HA GET, POST DELETE etc : these are methods of the controller
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           var values = await  _context.Values.ToListAsync();
           return   Ok (values);
        }

        // GET api/values/5
        [HttpGet("{id}")] //HA# pass value to method
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok  (value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}