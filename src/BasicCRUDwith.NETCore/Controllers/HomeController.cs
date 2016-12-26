using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDwith.NETCore.Models;
using BasicCRUDwith.NETCore.DbContexts;

namespace BasicCRUDwith.NETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentContext _context;
        public HomeController(
           StudentContext context
        )
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Students.ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            else
            {
                var data = _context.Students.FirstOrDefault(x => x.ID == id);
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,Name,Address,Contact")] Student student)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(m => m.ID == id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
