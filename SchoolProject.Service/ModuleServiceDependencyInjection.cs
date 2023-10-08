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
            return services.AddTransient<IStudentService, StudentService>();
        }
    }
}