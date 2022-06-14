using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViveroWebApi.Controllers
{
    [Route("Compras")]
    [ApiController]
    public class ViveroComprasController : ControllerBase
    {


        // GET: api/<ViveroComprasController>
        [Route("FindAll")]
        [HttpGet]
        public IActionResult Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<ViveroComprasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ViveroComprasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ViveroComprasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ViveroComprasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
