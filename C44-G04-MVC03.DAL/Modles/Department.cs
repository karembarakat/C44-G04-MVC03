using C44_G04_MVC03.DAL.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.DAL.Models
{
    public class Department : BaseEntity
    {
        public string Code{ get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }

        public List<Employee> Employees { get; set; }
    }
        
}
