using Microsoft.AspNetCore.Identity;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.IdentityModel.Tokens;
using MyProject.DomainService;
using MyProject.Infrastructure.ApplicationContext;
using MyProject.Models.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace MyProject.Infrastructure.Repository
{
    public class AuthenRepository : Reposotory<Admin>, IAuthenRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenRepository(ApplicationDBContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager) : base(context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<string> LoginAsync(Admin admin)
        {
            var user = await _userManager.FindByNameAsync(admin.UserName);

             await _signInManager.SignInAsync(user, isPersistent: true);
             var role = await _userManager.GetRolesAsync(user);
                return "Succeeded";
        }

       
        public async Task<bool> RegisterAsync(Admin admin)
        {
            //Kiểm tra xem tài khoản đã tồn tại chưa
            var checkUser = await Context.Set<Admin>()
                .Where(u => u.UserName == admin.UserName)
                .FirstOrDefaultAsync();
            if (checkUser != null)
            {
                return false;
            }
            
            var newAdmin = new IdentityUser()
            {
                UserName = admin.UserName,
                Email = admin.UserName,
            };
            
           
            //Kiem tra xem tai khoản dăng ký la admin hay nhân viên
            if (admin.UserName.Contains("@admin"))//chua cum ky tu nay thi la admin
            {
                Context.Set<Admin>().Add(admin);
                await _userManager.CreateAsync(newAdmin, admin.Password);
                var roleExists = await _roleManager.RoleExistsAsync("ADMIN");
                
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
                }

                var result = await _userManager.AddToRoleAsync(newAdmin, "ADMIN");
                await _signInManager.SignInAsync(newAdmin, isPersistent: true);
            }
            else
            {
                var newEmployee = new Employees
                {
                    UserName = admin.UserName,
                    Password = admin.Password,
                    CreateOn = admin.CreateOn,

                };

                var employeeIdentity = new IdentityUser
                {
                    UserName = admin.UserName,
                    PasswordHash = admin.Password,
                    Email = admin.UserName,
                };
                Context.Set<Employees>().Add(newEmployee);
                await _userManager.CreateAsync(employeeIdentity);

                var roleExists = await _roleManager.RoleExistsAsync("USER");


                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("USER"));
                }

                var result = await _userManager.AddToRoleAsync(employeeIdentity, "USER");
                await _signInManager.SignInAsync(employeeIdentity, isPersistent: true);
            }
          
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
