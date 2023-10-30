using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Dtos;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Infrastructure.Repository
{
    public class EvaluteRepository : Reposotory<KPIs>, IEvaluteRepository
    {
        public EvaluteRepository(ApplicationDBContext Context) : base(Context)
        {
        }

        public async Task<List<KPIsDto>> GetAllAsync()
        {
            var list = await Context.Set<KPIs>()
                .Select(p => new KPIsDto
            {
                Revenue = p.Revenue,
                DayOfMonth = p.DayOfMonth,
                CreateOn = p.CreateOn,

            }).ToListAsync();
            return list;
        }

        public async Task<decimal> GetRevenueByEmployeeAsync(int id)
        {
            var total = await Context.Set<KPIs>()
                .Where(e => e.EmployeeId == id)
                .SumAsync(e => e.Revenue);
            return total;
        }

        public async Task<int> GetDayByEmployeeAsync(int id)
        {
            var total = await Context.Set<KPIs>()
                .Where(e => e.EmployeeId == id)
                .CountAsync();
            return total;
        }
    }
}
