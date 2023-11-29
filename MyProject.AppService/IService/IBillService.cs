using MyProject.Models.Model;

namespace MyProject.AppService.IService;

public interface IBillService
{
    Task<bool> CreateBill(Bill bill);
    Task<List<Bill>> GetAll();
    Task<List<int>> GetProductId(int employeeId);
}