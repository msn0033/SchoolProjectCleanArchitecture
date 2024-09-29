using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Interface.Procedures;
using SchoolProject.Infrustructure.Interface.Views;
using SchoolProject.Infrustructure.Repositories;
using SchoolProject.Infrustructure.Repositories.Procedures;
using SchoolProject.Infrustructure.Repositories.Views;
using SchoolProject.Infrustructure.Seeding;
using System.Runtime.CompilerServices;

namespace SchoolProject.Infrustructure
{
    public  static class ModuleInfrustructureDependencyInjection
    {
        public static async Task<IServiceCollection> AddInfrustructureDependencyInjectionAsync(this IServiceCollection services)
        {
            //generic
            services.AddTransient(typeof(IGenericRepositoryAsync<>),typeof(GenericRepositoryAsync<>));
            //class
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            //view generic
            services.AddTransient<IViewRepository<DepartmentStudentCountView>, ViewDepartmentRepository>();

            //procedure
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();

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