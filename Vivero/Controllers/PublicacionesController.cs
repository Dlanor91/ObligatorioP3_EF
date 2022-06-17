using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero.Controllers
{
    public class PublicacionesController : Controller
    {
        // GET: PublicacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PublicacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicacionesController/Create
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

        // GET: PublicacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicacionesController/Edit/5
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

        // GET: PublicacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicacionesController/Delete/5
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
    }
}
