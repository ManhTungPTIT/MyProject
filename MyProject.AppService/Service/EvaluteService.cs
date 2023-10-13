using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Dtos;

namespace MyProject.AppService.Service;

public class EvaluteService : IEvaluteService
{
    private readonly IEvaluteRepository _repository;

    public EvaluteService(IEvaluteRepository _repository)
    {
        this._repository = _repository;
    }
    
    public async Task<List<KPIsDto>> GetAll()
    {
        return await _repository.GetAllAsync();
    }
}