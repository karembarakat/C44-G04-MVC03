using C44_G04_MVC03.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Interfaces
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetAll();

        Department? Get(int id);

        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);
      
    }
}
