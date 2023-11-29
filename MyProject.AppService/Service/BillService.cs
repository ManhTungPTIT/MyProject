using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Model;

namespace MyProject.AppService.Service;

public class BillService : IBillService
{
    private readonly IBillRepository _repository;

    public BillService(IBillRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> CreateBill(Bill bill)
    {
        return await _repository.CreateBillAsync(bill);
    }

    public async Task<List<Bill>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<List<int>> GetProductId(int employeeId)
    {
        return await _repository.GetProductId(employeeId);
    }
}