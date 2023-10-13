using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.AppService.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<bool> AddCustomer(Customers customer)
        {
            return await customerRepository.AddCustomerAsync(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await customerRepository.DeleteCustomerAsync(id);
        }

        public async Task<bool> EditCustomer(Customers customer)
        {
            return await customerRepository.EditCustomerAsync(customer);
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            return await customerRepository.GetAllAsync();
        }
    }
}
