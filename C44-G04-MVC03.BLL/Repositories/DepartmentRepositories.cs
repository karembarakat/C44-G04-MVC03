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
     public class DepartmentRepositories : GenericRepository<Department>, IDepartmentRepo
    {
        public DepartmentRepositories(CompanyDBContext context) : base(context)
        {

        }
    }
}
