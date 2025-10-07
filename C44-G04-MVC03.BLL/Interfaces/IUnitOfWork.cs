using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDepartmentRepo DepartmentRepo { get; }
        public IEmployeeRepository EmployeeRepository { get; }

        int Complete();

    }
}
