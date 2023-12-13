using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Service.Interface;
using SchoolProject.Service.Services;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentsService, DepartmentsService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}