using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;

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

    public async Task<bool> UpdateCompetence(KPIsDto kpi)
    {
        return await _repository.UpdateCompetence(kpi);
    }
}