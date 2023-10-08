using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Repositories;
using System.Runtime.CompilerServices;

namespace SchoolProject.Infrustructure
{
    public  static class ModuleInfrustructureDependencyInjection
    {
        public static IServiceCollection AddInfrustructureDependencyInjection(this IServiceCollection services)
        {
             services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }

    }
}