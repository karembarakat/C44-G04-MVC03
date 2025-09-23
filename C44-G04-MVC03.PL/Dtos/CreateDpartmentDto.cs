using System.ComponentModel.DataAnnotations;

namespace C44_G04_MVC03.PL.Dtos
{
    public class CreateDpartmentDto
    {
        [Required(ErrorMessage = "Code Is req")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Code Is Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Is CreateAt")]
        public DateTime CreateAt { get; set; }
    }
}
