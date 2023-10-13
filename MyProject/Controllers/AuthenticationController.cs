
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;
using MyProject.Models.Model;

namespace MyProject.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthenService service;
        public AuthenticationController(IAuthenService service, SignInManager<IdentityUser> signInManager)
        {
            this.service = service;
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> Login(string? userName, string? password)
        {
            string message = "";
            if(userName != null && password != null)
            {
                Admin admin = new Admin()
                {
                    UserName = userName,
                    Password = password,
                };

                var result = await service.Login(admin);
                if (string.IsNullOrEmpty(result))
                {
                    message = "Tài khoản hoặc mật khẩu không đúng";
                    return RedirectToAction("Register", routeValues: new {message});
                }
                
                var user = new IdentityUser()
                {
                    UserName = userName,
                    Email = userName,
                };
                
                var check = User.Identity.IsAuthenticated;
                if (check)
                {
                    return Redirect("/Customer/Index");
                }
            }
            return View();
        }
        public async Task<IActionResult> Register(string? userName, string? password, string? phone, DateTime day)
        {
            if(userName != null && password != null && phone != null ) {
                Admin admin = new Admin()
                {
                    UserName = userName,
                    Password = password,
                    Phone = phone,
                    CreateOn = day,
                };
                
                bool check =  await service.Register(admin);
                if (!check)
                {
                    string message = "Tài khoản đã tồn tại";
                    return RedirectToAction("Register", routeValues: new {message});
                }

               
                
                return Redirect("~/Authentication/Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return View("Login");
        }
    }
}
