﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Base.MiddleWare;
using SchoolProject.Core.Features.Students.Commands.Create;
using SchoolProject.Core.Filters;
using SchoolProject.Core.policy;
using Serilog;
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

            services.AddValidatorsFromAssembly(typeof(CreateStudentCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Configuration Logger
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();



            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.File("D:\\Activator\\msn00.txt",
            //        rollingInterval: RollingInterval.Day,
            //        rollOnFileSizeLimit: true)
            //    .CreateLogger();

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