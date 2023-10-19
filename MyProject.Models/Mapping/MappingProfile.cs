using AutoMapper;
using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminDto>();
            CreateMap<Customers, CustomerDto>();
            CreateMap<Employees, EmployeeDto>();
            CreateMap<KPIs,  KPIsDto>()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src));
            CreateMap<AdminCustomers, AdminCustomersDto>();
            CreateMap<AdminEmployees, AdminEmpoloyeeDto>();
        }
    }
}
