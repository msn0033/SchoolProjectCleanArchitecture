using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Infrustructure.Context;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SchoolProject.Core
{
    public static  class ModuleCoreDependencyInjection
    {
        public static IServiceCollection AddModuleCoreDependencyInjection(this IServiceCollection services)
        {
            //Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration Of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Configuration  Flent Validation


            // Get Validators
            services.AddValidatorsFromAssembly(typeof(AddStudentCommand).Assembly);
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}