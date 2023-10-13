using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using MyProject.Infrastructure.AutoFacModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });
            
            // Autofac integrationa
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(config => config.RegisterModule(new CoreModule()));
            
            //AddAuthentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new
                    Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //tu cap token
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    //ky vao token
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            }).AddCookie(options =>
            {
                options.Cookie.Name = "MyCookie";
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
            });
            

            builder.Services.AddAuthorization();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSwaggerGen();
            //Cookie setting
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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