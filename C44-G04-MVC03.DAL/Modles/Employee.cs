using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G04_MVC03.DAL.Modles
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
        public int? Age { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
