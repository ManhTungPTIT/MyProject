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
            CreateMap<Employees, EmployeeDto>()
                .ForMember(dest =>  dest.ProductDtos, act => act.MapFrom(src => src.Bills.Select(pc => pc.Product)));
            CreateMap<AdminCustomers, AdminCustomersDto>();
            CreateMap<AdminEmployees, AdminEmpoloyeeDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Bill, BillDto>()
                .ForMember(des => des.CustomerId, act => act.MapFrom(src => src.Customers.Id))
                .ForMember(des => des.EmployeeId, act => act.MapFrom(src => src.Employees.Id))
                .ForMember(des => des.ProductId, act => act.MapFrom(src => src.ProductBills.Select(pc => pc.ProductId)));
        }
    }
}
