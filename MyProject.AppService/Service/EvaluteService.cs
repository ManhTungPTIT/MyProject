using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;

namespace MyProject.AppService.Service;

public class EvaluteService : IEvaluteService
{
    private readonly IEvaluteRepository repository;
    private readonly IEmployeeService _service;

    public EvaluteService(IEvaluteRepository repository, IEmployeeService service)
    {
        this.repository = repository;
        _service = service;
    }
    
    public async Task<List<KPIsDto>> GetAll()
    {
        var list = new List<KPIsDto>();
        var listEmployee = await _service.GetAllEmployee();
        foreach (var user in listEmployee)
        {
            var totalRevenue = await repository.GetRevenueByEmployeeAsync(user.Id);
            var totalDay = await repository.GetDayByEmployeeAsync(user.Id);
            var KPI = totalRevenue / totalDay;
            var evalute = new KPIsDto
            {
                EMployeeName = user.UserName,
                Kpis = KPI,
            };
            
            list.Add(evalute);
            await _service.UpdateCompetence(evalute);
        }
        return list;
    }
}