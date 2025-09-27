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
    public class EmployeeRepository : GenericRepository<Employee>,  IEmployeeRepository
    {
        public EmployeeRepository(CompanyDBContext context) : base(context)
        {

        }   
    }
}
