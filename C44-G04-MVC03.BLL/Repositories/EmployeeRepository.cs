using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.DAL.Data.Contexts;
using C44_G04_MVC03.DAL.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>,  IEmployeeRepository
    {
        private readonly CompanyDBContext _Context;
        public EmployeeRepository(CompanyDBContext context) : base(context)
        {
            _Context = context;
        }


        public List<Employee>? GetbyName(string name)
        {
          return  _Context.Employees.Include(E => E.Department).Where(E => E.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
