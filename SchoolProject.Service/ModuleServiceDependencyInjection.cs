
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Permission;
using SchoolProject.Service.AuthServices.implementations;
using SchoolProject.Service.AuthServices.Interfaces;
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



            //Permission-Policy-based-Authorization

            //services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(Permission.Students.View, builder =>
            //    {
            //        builder.AddRequirements(new PermissionRequirement(Permission.Students.View));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Students.Create));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Students.Edit));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Students.Delete));
            //    });

            //    options.AddPolicy(Permission.Departments.Create, builder =>
            //    {
            //        builder.AddRequirements(new PermissionRequirement(Permission.Departments.View));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Departments.Create));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Departments.Edit));
            //        builder.AddRequirements(new PermissionRequirement(Permission.Departments.Delete));
            //    });

            //});
            return services;
        }
    }
}