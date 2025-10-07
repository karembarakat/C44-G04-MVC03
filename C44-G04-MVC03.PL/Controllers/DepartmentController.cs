using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.BLL.Repositories;
using C44_G04_MVC03.DAL.Models;
using C44_G04_MVC03.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace C44_G04_MVC03.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepo _departmentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_departmentRepo = departmentRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepo.GetAll();
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
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };

                //var count = _unitOfWork.DepartmentRepo.Add(department);
                _unitOfWork.DepartmentRepo.Add(department);
                var count = _unitOfWork.Complete();

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                    
                
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int id, string viewName = "Details")
        {
            var department = _unitOfWork.DepartmentRepo.Get(id);
            if (department == null)
                return NotFound();
            return View(viewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var department = _departmentRepo.Get(id);
            //if (department == null)
            //    return NotFound();

            return Details(id,"Edit");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        {
            if (!ModelState.IsValid)
            {
                var existingDepartment = _unitOfWork.DepartmentRepo.Get(id);
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

            //var count = _unitOfWork.DepartmentRepo.Update(department);
            _unitOfWork.DepartmentRepo.Update(department);
            var count = _unitOfWork.Complete();
            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var department = _departmentRepo.Get(id);
            //if (department == null)
            //    return NotFound();
            return Details(id,"Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department model)
        {
            if (ModelState.IsValid)
            {
            if (id != model.Id) return BadRequest(); // 400
                //var count = _unitOfWork.DepartmentRepo.Delete(model);
                _unitOfWork.DepartmentRepo.Delete(model);
                var count = _unitOfWork.Complete();

                if (count > 0) 
                { 
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }


    }
}
