using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Repositories;
using SchoolProject.Infrustructure.Seeding;
using System.Runtime.CompilerServices;

namespace SchoolProject.Infrustructure
{
    public  static class ModuleInfrustructureDependencyInjection
    {
        public static async Task<IServiceCollection> AddInfrustructureDependencyInjectionAsync(this IServiceCollection services)
        {
             services.AddTransient<IStudentRepository, StudentRepository>();
             services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            //Data Seeding
            using (var scop = services.BuildServiceProvider().CreateScope())
            {
                var rolemanager = scop.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                var usermanager = scop.ServiceProvider.GetRequiredService<UserManager<User>>();
                var dbcontext = scop.ServiceProvider.GetRequiredService<AppDbContext>();
                //var dbcontext2 = scop.ServiceProvider.GetService<AppDbContext>();
                await RoleSeeding.SeedRoleAddAsync(rolemanager);
                await UserSeeding.SeedSuperAdminUserAsync(usermanager, rolemanager, dbcontext);
            }
            return services;
        }

    }
}