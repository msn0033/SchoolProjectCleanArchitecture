
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<Interface.IAuthorizationService, AuthorizationService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IInstructorService, InstructorService>();


            return services;
        }
    }
}