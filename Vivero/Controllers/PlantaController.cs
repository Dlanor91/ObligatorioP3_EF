﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDeAplicacion;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Hosting;
using Vivero.Models;
using System.IO;

namespace Vivero.Controllers
{
    public class PlantaController : Controller
    {
        
        public IManejadorPlanta ManejadorPlanta { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public PlantaController(IManejadorPlanta manejadorPlanta, IWebHostEnvironment webHostEnvironment)
        {
            ManejadorPlanta=manejadorPlanta;
            WebHostEnvironment=webHostEnvironment;
        }

        // GET: PlantaController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                MostrarPlantaAtributos();
                IEnumerable<Planta> pl = ManejadorPlanta.MostrarTodasPlantas();                               
                return View(pl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Busquedas()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //Busqueda de Plantas por Nombre de Planta
        public ActionResult BusqPorNombre()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqPorNombre(string nombreBusqPlanta)
        {            
            try
            {
                if (nombreBusqPlanta == null)
                {
                    throw new Exception("Complete el campo de búsqueda.");                    
                }
                else
                {
                    nombreBusqPlanta = nombreBusqPlanta.Trim();
                    MostrarPlantaAtributos();
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.BusquedaNombre(nombreBusqPlanta);
                    if (plEncontradas.Count() == 0)
                    {
                        throw new Exception("No se encontraron coincidencias con " + nombreBusqPlanta + " .");
                    }
                    else
                    {
                        return View(plEncontradas);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //Busqueda de Plantas por Tipo de Planta
        public ActionResult BusqTipoPlanta()
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

        [HttpPost]
        public ActionResult BusqTipoPlanta(int busqTipoPlanta)
        {

            try
            {
                if (busqTipoPlanta == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    MostrarPlantaAtributos();
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasTipoPlanta(busqTipoPlanta);
                    if (plEncontradas.Count() == 0)
                    {
                        
                        throw new Exception("No se encontraron coincidencias con ese criterio de búsqueda.");
                    }
                    else
                    {                        
                        MostrarPlantaAtributos();
                        return View(plEncontradas);
                    }

                }
            }
            catch (Exception ex)
            {                
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;
                return View();
            }
        }                    

        //busqueda por tipo de ambiente
        public ActionResult BusqTipoAmbiente()
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
        
        [HttpPost]
        public ActionResult BusqTipoAmbiente(int busqTipoAmbiente)
        {
            try
            {
                if (busqTipoAmbiente == 0)
                {
                    throw new Exception("Complete el campo de búsqueda.");
                }
                else
                {
                    MostrarPlantaAtributos();
                    IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasTipoAmbiente(busqTipoAmbiente);
                    if (plEncontradas.Count() == 0)
                    {
                        
                        throw new Exception("No se encontraron plantas con ese criterio de búsqueda.");
                    }
                    else
                    {                        
                        return View(plEncontradas);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //Busqueda de Plantas por Altura menor que ciertas Plantas
        public ActionResult BusqMenorAltura()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqMenorAltura(int busqAlturaMinima)
        {
            try
            {
                 if (busqAlturaMinima == 0)
                {
                    throw new Exception("Complete el campo de búsqueda o introduzca una altura mayor que 0.");
                }
                else
                {
                    if (busqAlturaMinima<0) {
                        throw new Exception("Introduzca una altura mayor que 0.");
                    } 
                    else {
                        MostrarPlantaAtributos();
                        IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMenoresAlt(busqAlturaMinima);
                        if (plEncontradas.Count() == 0)
                        {
                            throw new Exception("No se encontraron plantas menores que " + busqAlturaMinima + " cm.");
                        }
                        else
                        {
                            return View(plEncontradas);
                        }
                    }                                       
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        
        //Busqueda de Plantas mayor Altura
        public ActionResult BusqMayorAltura()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult BusqMayorAltura(int busqAlturaMaxima)
        {
            try
            {
                if (busqAlturaMaxima == 0)
                {
                    throw new Exception("Complete el campo de búsqueda o introduzca una altura mayor que 0.");
                }
                else
                {
                    if (busqAlturaMaxima<0)
                    {
                        throw new Exception("Introduzca una altura mayor que 0.");
                    }
                    else
                    {
                        MostrarPlantaAtributos();
                        IEnumerable<Planta> plEncontradas = ManejadorPlanta.buscarPlantasMayoresAlt(busqAlturaMaxima);
                        if (plEncontradas.Count() == 0)
                        {
                            throw new Exception("No se encontraron plantas mayores que " + busqAlturaMaxima + " cm.");
                        }
                        else
                        {
                            return View(plEncontradas);
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
               

        // GET: PlantaController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {                
                MostrarPlantaAtributos();
                return View() ;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PlantaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelPlanta VMPlanta,int cantDiasRiego,string frecSeleccionada, int minimaDesc, int maximaDesc)
        {
            try
            {
                if (cantDiasRiego>0 && frecSeleccionada !="0")
                {
                    if (cantDiasRiego == 1)
                    {
                        VMPlanta.Planta.FrecuenciaRiego = cantDiasRiego + " vez por " + frecSeleccionada;
                    }
                    else
                    {
                        VMPlanta.Planta.FrecuenciaRiego = cantDiasRiego + " veces por " + frecSeleccionada;
                    }

                    bool validarNewTp = VMPlanta.Planta.Validar();

                    if (validarNewTp && VMPlanta.idIluminacion != 0 && VMPlanta.idTipoAmbiente != 0 && VMPlanta.idTipoPlanta != 0 && VMPlanta.Foto!=null)
                    {
                        if (VMPlanta.Planta.AlturaMax <= 0)
                        {
                            throw new Exception("La altura máxima no puede ser menor que 0cm.");
                        }
                        else
                        {
                            bool errorNombre = VMPlanta.Planta.ValidarFormatoNombre(VMPlanta.Planta.NombreCientifico);
                            if (!errorNombre)
                            {
                                VMPlanta.Planta.NombreCientifico = VMPlanta.Planta.NombreCientifico.Trim();
                                bool existeNombre = ManejadorPlanta.verificarNombreC(VMPlanta.Planta.NombreCientifico);
                                if (!existeNombre)
                                {
                                    VMPlanta.Planta.Descripcion = VMPlanta.Planta.Descripcion.Trim();
                                    VMPlanta.Planta.NombresVulgares = VMPlanta.Planta.NombresVulgares.Trim();
                                    bool descripcionValida = VMPlanta.Planta.ValidarDescripcion(VMPlanta.Planta.Descripcion, minimaDesc, maximaDesc);
                                    if (descripcionValida)
                                    {
                                        if (VMPlanta.Foto.ContentType == "image/jpeg" || VMPlanta.Foto.ContentType == "image/png")
                                        {
                                            string extension;
                                            if (VMPlanta.Foto.ContentType == "image/jpeg")
                                            {
                                                extension = ".jpg";
                                            }
                                            else
                                            {
                                                extension = ".png";
                                            }
                                            string nomArchivo = VMPlanta.Planta.NombreCientifico.Replace(" ", "_") + "_001"+extension;
                                            VMPlanta.Planta.Foto = nomArchivo;
                                            bool altaTP = ManejadorPlanta.AgregarPlanta(VMPlanta.Planta, VMPlanta.idTipoPlanta, VMPlanta.idTipoAmbiente, VMPlanta.idIluminacion);
                                            if (altaTP)
                                            {
                                                string rutaRaiz = WebHostEnvironment.WebRootPath;
                                                string rutaImagenes = Path.Combine(rutaRaiz, "img");//aqui lo une solo sin ver orden e imagenes es la carpeta de imagenes
                                                string rutaArchivo = Path.Combine(rutaImagenes, nomArchivo);
                                                FileStream stream = new FileStream(rutaArchivo, FileMode.Create); //para hacer la ruta un stream
                                                VMPlanta.Foto.CopyTo(stream);
                                                return RedirectToAction(nameof(Index));
                                            }
                                            else
                                            {
                                                throw new Exception("No fue posible el alta de esta nueva Planta.");
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("El archivo de la foto subida no es válida, tiene que ser extensión jpeg o png.");
                                        }

                                    }
                                    else
                                    {
                                        throw new Exception("El campo descripción debe estar entre " + minimaDesc + " y " + maximaDesc + " caracteres.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("El nombre de la Planta ya existe en la base de datos, ingrese otro.");
                                }
                            }
                            else
                            {
                                throw new Exception("El nombre de la Planta tiene espacios al principio o final y/o tiene números, verifíquelo.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Complete todos los campos.");
                    }
                }
                else
                {
                    throw new Exception("La frecuencia de riego no puede ser negativa y seleccione una unidad de tiempo.");
                }

            }
            catch (Exception ex)
            {
                MostrarPlantaAtributos();
                ViewBag.Error = ex.Message;

                return View();
            }

            return View();
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
