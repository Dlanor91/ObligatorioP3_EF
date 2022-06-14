using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vivero.Controllers
{
    [Route("Compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private IRepositorioCompra RepoCompras;

        public ComprasController(IRepositorioCompra repoCompras)
        {
            RepoCompras=repoCompras;
        }


        // GET: api/<ComprasController>
        [Route("FindAll")]
        [HttpGet]
        public ActionResult<Compra> Get()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                try
                {
                    var compras = RepoCompras.FindAll();
                    if (compras == null)
                    {
                        return NotFound();
                    }
                    return Ok(compras);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET api/<ComprasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComprasController>
        [Route("Alta")]
        [HttpPost]
        public ActionResult<Compra> Post([FromBody] Compra compra)
        {
            try 
            {
                if (compra == null)
                    return BadRequest("No se puede pasar una compra en null");
                if (RepoCompras.Add(compra))
                    return CreatedAtRoute("Get", new { id = compra.Id }, compra);
                return Conflict(compra);
            }
            catch (Exception ex) 
            {
                return StatusCode(500);
            }
            
        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComprasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
