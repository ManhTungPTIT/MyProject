using Microsoft.EntityFrameworkCore;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Model;


namespace MyProject.Infrastructure.Repository
{
    public class CustomerRepository : Reposotory<Customers>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<bool> AddCustomerAsync(Customers customer)
        {
            //check customer current
            var checkCustomer = await Context.Set<Customers>()
                .Where(c => c.UserName == customer.UserName)
                .FirstOrDefaultAsync();

            if (checkCustomer != null)
            {
                return false;
            }

            Context.Add(customer);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await Context.Set<Customers>().FirstOrDefaultAsync(c => c.Id == id);

            customer.DeleteOn = DateTime.Now;
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var cus = await Context.Set<Customers>()
                .Where(u => u.UserName == name)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
            return cus;
            
        }

        public async Task<bool> EditCustomerAsync(Customers customer)
        {
            var customerCurrent = await Context.Set<Customers>()
                .Where(u => u.Id == customer.Id)
                .FirstOrDefaultAsync();

            customerCurrent.UserName = customer.UserName;
            customerCurrent.Phone = customer.Phone;
            customerCurrent.Address = customer.Address;
            customerCurrent.UpdateOn = DateTime.Now;
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var list = await Context.Set<Customers>()
                .Where(u => u.DeleteOn == null)
                .Select(u => new CustomerDto
            {
                Id = u.Id,
                UserName = u.UserName,
                CreateOn = (DateTime) u.CreateOn,
                Phone = u.Phone,
                Address = u.Address,
            }).ToListAsync();
            return list;
        }
    }
}
