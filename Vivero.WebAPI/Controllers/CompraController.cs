using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using LogicaDeAplicacion;
using ViveroDTO;



namespace Vivero.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        public IManejadorCompra ManejadorCompra { get; set; }

        public CompraController(IManejadorCompra manejadorCompra)
        {
            ManejadorCompra=manejadorCompra;
        }

        // GET: api/Compra
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

                return CreatedAtRoute("Get", new { id = plazaCompra.Id }, plazaCompra);
                //return Created("api/Compra/Buscar/"+plazaCompra.Id, plazaCompra);

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
        [Route("Planta/{idPlanta}", Name = "Planta")]
        public IActionResult Planta(int idPlanta)
        {
            try
            {
                if (idPlanta ==0) return BadRequest();                

                IEnumerable<Compra> compras = ManejadorCompra.MostrarComprarPorIdPlanta(idPlanta);               

                IEnumerable<DTOCompra> datosCompra = compras.Select(compras => new DTOCompra()
                {
                    Id = compras.Id,
                    Fecha = compras.Fecha,
                    TotalCompra = compras.PrecioFinal(22),
                    Items = compras.Item.Select(it => new DTOItem { Cantidad = it.Cantidad, 
                                                                    PrecioUnitario = it.PrecioUnitario ,
                                                                    Planta = new DTOPlanta { NombreCientifico = it.Planta.NombreCientifico,
                                                                                             Descripcion = it.Planta.Descripcion,
                                                                                             AlturaMax = it.Planta.AlturaMax,
                                                                                             Foto = it.Planta.Foto,
                                                                                             FrecuenciaRiego = it.Planta.FrecuenciaRiego,
                                                                                             Temperatura = it.Planta.Temperatura,
                                                                                             TipoAmbiente = new DTOTipoAmbiente { Ambiente = it.Planta.TipoAmbiente.Ambiente},
                                                                                             TipoIlumincacion = new DTOIluminacion { TipoIluminacion = it.Planta.TipoIlumincacion.TipoIluminacion },
                                                                                             TipoPlanta = new DTOTipoPlanta {Nombre = it.Planta.TipoPlanta.Nombre, Descripcion = it.Planta.TipoPlanta.Descripcion},
                                                                                             NombresVulgares = it.Planta.NombresVulgares
                                                                    } }),                   

                    //Importacion
                    DescripcionSanitaria = compras is Importacion ? (compras as Importacion).DescripcionSanitaria : null,
                    //Plaza
                   CostoFlete = compras is Plaza ? (compras as Plaza).CostoFlete: 0

                   
                }); 

                return Ok(datosCompra);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

