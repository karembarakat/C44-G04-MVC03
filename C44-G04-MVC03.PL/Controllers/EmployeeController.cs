using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.DAL.Models;
using C44_G04_MVC03.DAL.Modles;
using C44_G04_MVC03.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace C44_G04_MVC03.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {


            var employees = _employeeRepository.GetAll();

            //ViewData["Message"] = "Hello from EmployeeController Index Action";
           
            //ViewBag.Message = "Hello from EmployeeController Index Action";
            return View(employees);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {

                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    isDeleted = model.isDeleted,
                    Age = model.Age,
                    HireDate = model.HireDate,
                    CreateAt = model.CreateAt
                };

                var count = _employeeRepository.Add(employee);
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
            var employee = _employeeRepository.Get(id);
            if (employee == null)
                return NotFound();
            return View(viewName, employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id is null) return BadRequest(); // 400
            var employee = _employeeRepository.Get(id.Value);
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
                CreateAt = employee.CreateAt
            };
            return View(employeeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, CreateEmployeeDto model)
        {
            
            if (ModelState.IsValid)
            {
                //if (id != model.Id) return BadRequest(); // 400
                var employee = new Employee()
                {
                    Id = id,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    isDeleted = model.isDeleted,
                    Age = model.Age,
                    HireDate = model.HireDate,
                    CreateAt = model.CreateAt
                };
                var count = _employeeRepository.Update(employee);
                if (count > 0)
                {
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
                var count = _employeeRepository.Delete(model);

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(model);
        }

    }
}
