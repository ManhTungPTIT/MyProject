using Microsoft.AspNetCore.Identity;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DomainService
{
    public interface IAuthenRepository
    {
        public Task<bool> RegisterAsync(Admin admin);
        public Task<string> LoginAsync(Admin admin);
    }
}
