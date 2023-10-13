using MyProject.Models.Dtos;

namespace MyProject.AppService.IService;

public interface IEvaluteService
{
    Task<List<KPIsDto>> GetAll();
}