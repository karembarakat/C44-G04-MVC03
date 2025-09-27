using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.BLL.Repositories;
using C44_G04_MVC03.DAL.Models;
using C44_G04_MVC03.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace C44_G04_MVC03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);


        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateDpartmentDto model)
        {

            
            if (ModelState.IsValid) {
                var department = new Department
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };

                var count =_departmentRepo.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                    
                
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentRepo.Get(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentRepo.Get(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        {
            if (!ModelState.IsValid)
            {
                var existingDepartment = _departmentRepo.Get(id);
                if (existingDepartment == null)
                    return NotFound();
                return View(model);
            }
            var department = new Department
            {
                Id = id,
                Code = model.Code,
                Name = model.Name,
                CreateAt = model.CreateAt
            };

            var count = _departmentRepo.Update(department);
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


    }
}
