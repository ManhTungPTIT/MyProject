using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;
using MyProject.Models.Model;

namespace MyProject.AppService.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    

    public async Task<List<EmployeeDto>> GetAllEmployee()
    {
        return await _repository.GetAllEmployeeAsync();
    }

    public async Task<bool> EditEmployee(EmployeeDto employeeDto)
    {
        return await _repository.EditEmployeeAsync(employeeDto);
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        return await _repository.DeleteEmployeeAsync(id);
    }

    public async Task<bool> UpdateKpiEmployee(Employees employees)
    {
        return await _repository.UpdateKpiEmployeeAsync(employees);
    }

    public async Task<Employees> GetEmployeeByName(string name)
    {
        return await _repository.GetEmployeeByName(name);
    }

    public async Task<int> GetIdByName(string name)
    {
        return await _repository.GetIdByNameAsync(name);
    }

    public async Task<List<EmployeeDto>> GetEmployeeByProduct(int productId)
    {
        return await _repository.GetEmployeeByProduct(productId);
    }
}