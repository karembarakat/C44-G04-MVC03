using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace C44_G04_MVC03.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Name Is Required!!")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email Is not Vaild")]
        public string Email { get; set; }
        
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
        [Range(22,60,ErrorMessage ="Age Must Be between 22 and 60")]
        public int? Age { get; set; }
        [DisplayName("Hiring Date")]
        public DateTime HireDate { get; set; }
        [DisplayName("Date Of Creation")]
        public DateTime CreateAt { get; set; }
    }
}
