using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.DomainService;

public interface IBillRepository
{
    Task<bool> CreateBillAsync(Bill bill);
    Task<List<Bill>> GetAllAsync();
    Task<List<int>> GetProductId(int employeeId);
}