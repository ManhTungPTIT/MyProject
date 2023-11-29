using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.AppService.IService
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAll();
        Task<bool> AddCustomer(Customers customer);
        Task<bool> EditCustomer(Customers customer);
        Task<bool> DeleteCustomer(int id);
        Task<int> GetIdByName(string name);
    }
}
