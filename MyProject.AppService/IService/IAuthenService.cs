using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.AppService.IService
{
    public interface IAuthenService
    {
        Task<bool> Register(Admin admin);
        Task<string> Login(Admin admin);
    }
}
