using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.AppService.IService;
using MyProject.Models.Model;

namespace MyProject.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenService _service;

        public AuthenticationController(IAuthenService service)
        {
            this._service = service;
            
        }

        public async Task<IActionResult> Login(string? userName, string? password)
        {
            if (userName != null && password != null)
            {
                Admin admin = new Admin()
                {
                    UserName = userName,
                    Password = password,
                };

                var result = await _service.Login(admin);

                if (string.IsNullOrEmpty(result))
                {
                    var message = "Tài khoản hoặc mật khẩu không đúng";
                    return RedirectToAction("Register", routeValues: new { message });
                }
                if(userName.Contains("@admin"))
                {
                    return Redirect("/Customer/Index");
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }

            return View();
        }

        public async Task<IActionResult> Register(string? userName, string? password, string? phone, DateTime day)
        {
            if (userName != null && password != null && phone != null)
            {
                    Admin admin = new Admin()
                    {
                        UserName = userName,
                        Password = password,
                        Phone = phone,
                        CreateOn = day,
                    };

                    var check = await _service.Register(admin);
                    if (!check)
                    {
                        string message = "Tài khoản đã tồn tại";
                        return RedirectToAction("Register", routeValues: new { message });
                    }
                    return Redirect("~/Customer/Index");
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