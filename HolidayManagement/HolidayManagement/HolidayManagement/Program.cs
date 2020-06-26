using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayManagement.ApplicationLogic.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HolidayManagement
{
    public class Program
    {
        public static void InitiateAdmin(EmployeeService employeeService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Configuration = configuration;
            string name = "hr@yahoo.com";
            string email = "hr@yahoo.com";
            string password = "P@ssw0rd";

            IdentityUser admin = new IdentityUser
            {
                UserName = name,
                Email = email
            };

            var adminExists = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            
            if (adminExists == null)
            {
                userManager.CreateAsync(admin, password).GetAwaiter().GetResult();
                var role = new IdentityRole("HR");
                roleManager.CreateAsync(role).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "HR").GetAwaiter().GetResult();
            }
            if (userManager.IsInRoleAsync(admin, "HR").GetAwaiter().GetResult() == false)
            {
                userManager.AddToRoleAsync(admin, "HR").GetAwaiter().GetResult();
            }
        }
        public static void Main(string[] args)
        {

            IHost host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<IdentityUser>>();
                var employeeService = services.GetService<EmployeeService>();
                InitiateAdmin(employeeService, userManager, roleManager);

            }

            host.Run();
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
