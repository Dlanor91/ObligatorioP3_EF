using Dominio.EntidadesVivero;
using LogicaDeAplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero.Controllers
{
    public class UsuarioController : Controller
    {
        public IManejadorUsuario ManejadorUsuario { get; set; }
        public IManejadorParametroSistema ManejadorPS { get; set; }

        public UsuarioController(IManejadorUsuario manejadorUsuario, IManejadorParametroSistema manejadorPS)
        {
            ManejadorUsuario=manejadorUsuario;
            ManejadorPS=manejadorPS;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") == null)
            {               
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(string emailUsuario, string contrasenia,string accion)
        {
            try
            {               
                    if (emailUsuario == null || contrasenia == null)
                    {
                        throw new Exception("Complete todos los campos.");
                    }
                    else
                    {
                        if (emailUsuario.IndexOf("@")==-1)
                        {
                            throw new Exception("Debe tener al menos un @ para que sea un email válido.");
                        }
                        else
                        {
                            if (contrasenia.Length<6)
                            {
                                throw new Exception("La contraseña debe tener un mínimo de 6 caracteres.");
                            }
                            else
                            {
                                Usuario logueado = ManejadorUsuario.IngresoExitoso(emailUsuario, contrasenia);
                                if (logueado !=null)
                                {
                                    HttpContext.Session.SetString("datosNombreUsuario", logueado.Email);
                                    return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                    throw new Exception("El email ingresado no está en nuestra base de batos o la contraseña es incorrecta, verifíquelo.");
                                }
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
        public IActionResult CerrarSession()
        {
            if (HttpContext.Session.GetString("datosNombreUsuario") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Registro() {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(string Usuario)
        {
            try
            {
                bool usuario1 = ManejadorUsuario.PrecargaUsuarios(new Usuario {Email = "rl8506@gmail.com", Contrasenia = "Rl2022"});
                bool usuario2 = ManejadorUsuario.PrecargaUsuarios(new Usuario { Email = "mauri@gmail.com", Contrasenia = "MF2022" });
                bool usuario3 = ManejadorUsuario.PrecargaUsuarios(new Usuario { Email = "naty@gmail.com", Contrasenia = "Nd2022" });
                bool usuario4 = ManejadorUsuario.PrecargaUsuarios(new Usuario { Email = "admin@gmail.com", Contrasenia = "Admin2022" });               
                bool precarga = ManejadorPS.AltaParametros(new ParametroSistema
                {
                    TasaIVA = 22,
                    TasaDescuentoAmericaSur = 10,
                    TasaImportacionDGI = 20,
                    ValorMinimoDescripcionTP = 10,
                    ValorMaximoDescripcionTP = 200,
                    ValorMinimoDescripcionPL = 10,
                    ValorMaximoDescripcionPL = 500
                });
                if (usuario1 && usuario2 && usuario3 && usuario4 && precarga)
                {
                    return RedirectToAction("Login", "Usuario");                    
                }
                else
                {
                    throw new Exception("Usuarios ya existentes y precarga ya realizada.");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Usuarios ya existentes y precarga ya realizada.";
                return View();
            }            
        }
    }
}
