using AutoMapper;
using C44_G04_MVC03.DAL.Modles;
using C44_G04_MVC03.PL.Dtos;

namespace C44_G04_MVC03.PL.Mapping
{

    public class EmployeeProfile : Profile
    {
       public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto,Employee>().ReverseMap();
            //CreateMap<Employee, CreateEmployeeDto>();
        }
    }
}
