using MyProject.AppService.IService;
using MyProject.DomainService;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.AppService.Service
{
    public class AuthenService : IAuthenService
    {
        private readonly IAuthenRepository repository;

        public AuthenService(IAuthenRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Login(Admin admin)
        {
            return await repository.LoginAsync(admin);
        }

        public async Task<bool> Register(Admin admin)
        {
            return await repository.RegisterAsync(admin);
        }
    }
}
