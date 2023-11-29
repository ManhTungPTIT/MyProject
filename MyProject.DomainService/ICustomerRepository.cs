using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DomainService
{
    public interface ICustomerRepository 
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<bool> AddCustomerAsync(Customers customer);
        Task<bool> EditCustomerAsync(Customers customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<int> GetIdByNameAsync(string name);
    }
}
