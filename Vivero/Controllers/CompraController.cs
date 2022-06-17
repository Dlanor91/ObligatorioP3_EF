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
        public ActionResult Index()
        {
            MostrarPlantaAtributos();
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Index(int idTipoPlanta)
        {
            try
            {
                if (idTipoPlanta == null)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {                   
                    //MostrarPlantaAtributos();
                    //IEnumerable<Planta> plEncontradas = ManejadorPlanta.BusquedaNombre(nombreBusqPlanta);
                    //if (plEncontradas.Count() == 0)
                    //{
                    //    throw new Exception("No se encontraron coincidencias con " + nombreBusqPlanta + " .");
                    //}
                    //else
                    //{
                    //    return View(plEncontradas);
                    //}

                }
            }
            catch (Exception ex)
            {
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
