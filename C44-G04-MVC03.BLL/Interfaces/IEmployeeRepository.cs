using C44_G04_MVC03.DAL.Models;
using C44_G04_MVC03.DAL.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        List<Employee>? GetbyName(string name);
        //IEnumerable<Employee> GetAll();

        //Employee? Get(int id);

        //int Add(Employee model);
        //int Update(Employee model);
        //int Delete(Employee model);
    }
}
