using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using SchoolProject.Core.Features.Students.Commands.Models;
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


            // Get Validators
            services.AddValidatorsFromAssembly(typeof(AddStudentCommand).Assembly);
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Localization
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-US"),
                            new CultureInfo("de-DE"),
                            new CultureInfo("fr-FR"),
                            new CultureInfo("ar-SA")
                        };
                options.DefaultRequestCulture = new RequestCulture("ar-SA");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return services;
        }
    }
}