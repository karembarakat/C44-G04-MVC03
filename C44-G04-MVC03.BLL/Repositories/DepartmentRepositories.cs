using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.DAL.Data.Contexts;
using C44_G04_MVC03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Repositories
{
     public class DepartmentRepositories : IDepartmentRepo
    {


        private readonly CompanyDBContext _context;

        public DepartmentRepositories(CompanyDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public Department? Get(int id)
        {
            return _context.Departments.Find(id);
        }


        public int Add(Department model)
        {
            _context.Departments.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Department model)
        {
            _context.Departments.Update(model);
            return _context.SaveChanges();
        }


        public int Delete(Department model)
        {
            _context.Departments.Remove(model);
            return _context.SaveChanges();
        }

    }
}
