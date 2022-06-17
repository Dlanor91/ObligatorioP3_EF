using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using LogicaDeAplicacion;
using ViveroDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vivero.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {      
        public IManejadorCompra ManejadorCompra { get; set; }
        public IManejadorParametroSistema ManejadorParametrosSist { get; set; }

        public CompraController(IManejadorCompra manejadorCompra, IManejadorParametroSistema manejadorParametrosSist)
        {
            ManejadorCompra = manejadorCompra;
            ManejadorParametrosSist = manejadorParametrosSist;
        }



        // GET: api/Compra/Plaza
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ManejadorCompra.MostrarTodasCompras());
        }

        // GET api/Compra/5
        [HttpGet("{id}")]
        [Route("Buscar/{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id ==0) return BadRequest();
                Compra buscado = ManejadorCompra.MostrarCompraId(id);
                if (buscado == null) return NotFound();

                return Ok(buscado);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // POST api/Compra/Plaza

        [HttpPost]
        [Route("Plaza")]
        public IActionResult Post([FromBody] Plaza plazaCompra)
        {
            try
            {                
                if (!plazaCompra.Validar()) return BadRequest();
                
                bool ok = ManejadorCompra.AgregarCompra(plazaCompra); 

                if (!ok) return Conflict();

                return Created("api/Compra/Buscar/"+plazaCompra.Id, plazaCompra);
                
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/Compra/Importacion
        [HttpPost]
        [Route("Importacion")]
        public IActionResult Post([FromBody] Importacion impoCompra)
        {
            try
            {
                if (!impoCompra.Validar()) return BadRequest();
                bool ok = ManejadorCompra.AgregarCompra(impoCompra);

                if (!ok) return Conflict();

                return Created("api/Compra/Buscar/" + impoCompra.Id, impoCompra);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/Compra/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Compra/5 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/Compra/Planta/idPlanta
        [HttpGet("{idPlanta}")]
        [Route("Planta/{idPlanta}", Name = "BuscarPlanta")]
        public IActionResult BuscarPlanta(int idPlanta)
        {
            try
            {
                if (idPlanta ==0) return BadRequest();

                IEnumerable<Compra> compras = ManejadorCompra.MostrarComprarPorIdPlanta(idPlanta);
               
                IEnumerable<ParametroSistema> datosSistema = ManejadorParametrosSist.TodosLosParametros();
                IEnumerable<DTOParametroSistema> paraSistema = datosSistema.Select(datosSistema => new DTOParametroSistema()
                {
                    DescuentoAmericaSur = datosSistema.DescuentoAmericaSur,
                    TasaImportacionDGI = datosSistema.TasaImportacionDGI,
                    TasaIVA = datosSistema.TasaIVA
                });
                IEnumerable<DTOCompra> datosCompra = compras.Select(compras => new DTOCompra()
                {
                    Id = compras.Id,
                    Fecha = compras.Fecha,
                    TotalCompra = compras.PrecioFinal(),
                   NombreCientifico = compras.Item.Where(it => it.Planta.NombreCientifico),
                    Cantidad = compras.Item.Select(it => it.Cantidad)
                }) ;

                return Ok(ManejadorCompra.MostrarComprarPorIdPlanta(idPlanta));

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
