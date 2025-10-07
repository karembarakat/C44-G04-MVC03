using C44_G04_MVC03.BLL.Interfaces;
using C44_G04_MVC03.BLL.Repositories;
using C44_G04_MVC03.DAL.Data.Contexts;
using C44_G04_MVC03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL
{
    public class UnitOFwork : IUnitOfWork
    {
        private readonly CompanyDBContext _context;

        public IDepartmentRepo DepartmentRepo { get; }

        public IEmployeeRepository EmployeeRepository {get;}

        public UnitOFwork(CompanyDBContext context)
        {
            _context = context;
            DepartmentRepo = new DepartmentRepositories(_context);
            EmployeeRepository = new EmployeeRepository(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
