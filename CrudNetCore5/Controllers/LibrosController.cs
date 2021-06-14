using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {

        private ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> libros = _context.Libro ;
            return View(libros);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid) {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["msg"] = "El libro se registró correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http get Edit
        public IActionResult Edit(int? id) {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if ( libro == null ) {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["msg"] = "El libro se actualizó correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http get Edit
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["msg"] = $"El libro {id} se eliminó correctamente";

            return RedirectToAction("Index");
        }


    }
}
