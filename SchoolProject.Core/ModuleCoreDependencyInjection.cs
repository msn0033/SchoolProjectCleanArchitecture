using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Filters;
using SchoolProject.Core.policy;
using System.Globalization;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencyInjection
    {
        public static IServiceCollection AddModuleCoreDependencyInjection(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           
            //Configuration Of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //Configuration  Flent Validation

            services.AddValidatorsFromAssembly(typeof(AddStudentCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

           //add filters
            services.AddControllers(op => 
            {
                op.Filters.Add<PermissionBasedAuthorizationFilter>();
            });

            // add policy
            services.AddAuthorization(option => {
                option.AddPolicy("CityFromJeddah", bu => bu.AddRequirements(new CityFromJeddahRequirement()));
            });
            services.AddScoped<IAuthorizationHandler, CityAuthorizationHandler>();
          
            return services;
        }
    }
}