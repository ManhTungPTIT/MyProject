using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using MyProject.Infrastructure.AutoFacModels;
using Microsoft.AspNetCore.Authorization;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });

            builder.Services.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/Contact");
                options.Conventions.AuthorizeFolder("/Private");
                options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
            });
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                options.LoginPath = "/Authentication/Login";
                options.AccessDeniedPath = "/Authentication/Login";
                options.SlidingExpiration = true;
            });
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            // Autofac integrationa
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(config => config.RegisterModule(new CoreModule()));
            
            //AddAuthentication
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });
            
            builder.Services.AddAuthorization();
            builder.Services.AddHttpContextAccessor();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentication}/{action=Login}/{id?}");
           
            app.Run();
        }
    }
}