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
            MostrarPlantaAtributos();
            return View();
        }
        //Post
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

        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
