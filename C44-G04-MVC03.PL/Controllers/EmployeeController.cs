using AutoMapper;
using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.DAL.Models;
using C44_G04_MVC03.DAL.Modles;
using C44_G04_MVC03.PL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace C44_G04_MVC03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepo _departmentRepo;

        private readonly IMapper _mapper;

        public EmployeeController(
            //IEmployeeRepository employeeRepository,
            //IDepartmentRepo departmentRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            //_employeeRepository = employeeRepository;
            //_departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(string? searchInput)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(searchInput))
            {

                 employees = _unitOfWork.EmployeeRepository.GetAll();
            }
            else
            {
                 employees = _unitOfWork.EmployeeRepository.GetbyName(searchInput);
            }


            //ViewData["Message"] = "Hello from EmployeeController Index Action";

            //ViewBag.Message = "Hello from EmployeeController Index Action";
            return View(employees);
        }

        [HttpGet]

        public IActionResult Create()
        {
            var department = _unitOfWork.DepartmentRepo.GetAll();
            ViewData["Departments"] = department;
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                //var employee = new Employee()
                //{
                //    // MAnual Mapping
                //    Name = model.Name,
                //    Email = model.Email,
                //    Address = model.Address,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    IsActive = model.IsActive,
                //    isDeleted = model.isDeleted,
                //    Age = model.Age,
                //    HireDate = model.HireDate,
                //    CreateAt = model.CreateAt,
                //    DepartmentId = model.DepartmentId
                //};
                var employee = _mapper.Map<Employee>(model);
                _unitOfWork.EmployeeRepository.Add(employee);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Message"] = "Employee Created Successfully";
                    return RedirectToAction(nameof(Index));
                }


            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int id, string viewName = "Details")
        {
            var employee = _unitOfWork.EmployeeRepository.Get(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var department = _unitOfWork.DepartmentRepo.GetAll();
            ViewData["Departments"] = department;
            if (id is null) return BadRequest(); // 400
            var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null) return NotFound(); // 404
            var employeeDto = new CreateEmployeeDto()
            {
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                Phone = employee.Phone,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                isDeleted = employee.isDeleted,
                Age = employee.Age,
                HireDate = employee.HireDate,
                CreateAt = employee.CreateAt,
                DepartmentId = employee.DepartmentId
            };
            var dto = _mapper.Map<CreateEmployeeDto>(employee);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee model)
        {
            
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest(); // 400
                //if(id != model.Id) return BadRequest(); // 400
                //var count = _unitOfWork.EmployeeRepository.Update(model);
                _unitOfWork.EmployeeRepository.Update(model);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest(); // 400
                //var count = _unitOfWork.EmployeeRepository.Delete(model);
                 _unitOfWork.EmployeeRepository.Delete  (model);
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
