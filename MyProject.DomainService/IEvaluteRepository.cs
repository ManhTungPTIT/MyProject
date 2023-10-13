using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DomainService
{
    public interface IEvaluteRepository
    {
        Task<List<KPIsDto>> GetAllAsync();

        
    }
}
