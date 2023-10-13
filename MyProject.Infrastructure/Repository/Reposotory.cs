using Microsoft.EntityFrameworkCore;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class Reposotory<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDBContext Context;
        private DbSet<T> _dbSet;

        public Reposotory(ApplicationDBContext Context)
        {
            this.Context = Context;
            _dbSet = this.Context.Set<T>(); 
        }
    }
}
