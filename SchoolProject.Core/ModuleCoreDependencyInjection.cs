using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SchoolProject.Core
{
    public static  class ModuleCoreDependencyInjection
    {
        public static IServiceCollection AddModuleCoreDependencyInjection(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}