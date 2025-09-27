using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.DAL.Data.Contexts;
using C44_G04_MVC03.DAL.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDBContext _Context;

        public EmployeeRepository(CompanyDBContext context)
        {
            _Context = context;
        }

        public int Add(Employee model)
        {
            _Context.Employees.Add(model);
            return _Context.SaveChanges();
        }

        public int Delete(Employee model)
        {
            _Context.Employees.Remove(model);
            return _Context.SaveChanges();
        }

        public Employee? Get(int id)
        {
            return _Context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _Context.Employees.ToList();
        }

        public int Update(Employee model)
        {
            _Context.Employees.Update(model);
            return _Context.SaveChanges();
        }
    }
}
