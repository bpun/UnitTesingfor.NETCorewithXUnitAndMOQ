using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BasicCRUDwith.NETCore.Models;
using BasicCRUDwith.NETCore.Repositories;

namespace BasicCRUDwith.NETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseRepository<Student> _iRepository;
        public HomeController(
           IBaseRepository<Student> iRepository
        )
        {
            _iRepository = iRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _iRepository.GetAll().ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _iRepository.Add(student);
                _iRepository.Commit();

                return View("Index");
                // return RedirectToAction("Index");
            }
            else{ 
                return View("Create");
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                var data = _iRepository.GetById(id);
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
                _iRepository.Update(student);
                _iRepository.Commit();

                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _iRepository.GetById(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            _iRepository.Delete(student);
            _iRepository.Commit();

            return View("Index");
          //  return RedirectToAction("Index");
        }
    }
}
