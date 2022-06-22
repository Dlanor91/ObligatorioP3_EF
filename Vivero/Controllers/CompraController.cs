using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViveroDTO;
using System.Net.Http;
using Newtonsoft.Json;
using LogicaDeAplicacion;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Hosting;
using Vivero.Models;
using System.IO;

namespace Vivero.Controllers
{
    public class CompraController : Controller
    {
        public IManejadorPlanta ManejadorPlanta { get; set; }
        public IManejadorParametroSistema ManejadorPS { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public CompraController(IManejadorPlanta manejadorPlanta, IManejadorParametroSistema manejadorPS, IWebHostEnvironment webHostEnvironment)
        {
            ManejadorPlanta=manejadorPlanta;
            ManejadorPS=manejadorPS;
            WebHostEnvironment=webHostEnvironment;
        }

        // GET: CompraController
        public ActionResult BusqIdTipoPlanta()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                MostrarPlantaAtributos();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }           
        }
        //Post: CompraController
        [HttpPost]
        public ActionResult BusqIdTipoPlanta(int ? idTipoPlanta)
        {
            try
            {
                if (idTipoPlanta == null)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    MostrarPlantaAtributos();
                    List<DTOCompra> listCompras = new List<DTOCompra>();

                    HttpClient cliente = new HttpClient();
                    string URL = "http://localhost:49178/api/Compra/Planta/"+idTipoPlanta;
                    Task<HttpResponseMessage> respuesta =
                        cliente.GetAsync(URL);

                    respuesta.Wait();

                    if (respuesta.Result.IsSuccessStatusCode)
                    {
                        Task<string> contenido = respuesta.Result.Content.ReadAsStringAsync();
                        contenido.Wait();

                        string json = contenido.Result;
                        listCompras = JsonConvert.DeserializeObject<List<DTOCompra>>(json);
                    }
                    else
                    {
                        MostrarPlantaAtributos();
                        ViewBag.Error = "No se pueden mostrar todas las compras.";
                    }

                    return View(listCompras);

                }
            }
            catch (Exception ex)
            {
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;
                return View();
            }
        } 

        private void MostrarPlantaAtributos()
        {
            ViewModelPlanta VMPlantasAtr = new ViewModelPlanta();
            VMPlantasAtr.TipoPlanta = ManejadorPlanta.TraerTodosTiposPlantas();
            ViewBag.TipoPlantas = VMPlantasAtr.TipoPlanta;
            VMPlantasAtr.TipoAmbiente = ManejadorPlanta.TraerTodosTiposAmbientes();
            ViewBag.TipoAmbientes = VMPlantasAtr.TipoAmbiente;
            VMPlantasAtr.Iluminacion = ManejadorPlanta.TraerTodosIluminaciones();
            ViewBag.Iluminaciones = VMPlantasAtr.Iluminacion;
        }
    }
}
