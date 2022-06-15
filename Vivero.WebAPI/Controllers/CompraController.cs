using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using LogicaDeAplicacion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vivero.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        //public IRepositorioCompra RepoCompra { get; set; }

        //public CompraController(IRepositorioCompra repo)
        //{
        //    RepoCompra=repo;
        //}

        public IManejadorCompra ManejadorCompra { get; set; }

        public CompraController(IManejadorCompra manejadorCompra)
        {
            ManejadorCompra=manejadorCompra;
        }


        // GET: api/<CompraController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ManejadorCompra.MostrarTodasCompras());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
