

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace LocalizationLanguage
{
    public static class ModuleLocalizationLanguageDependencyInjection
    {
        public static IServiceCollection AddLocalizationLanguageDependencyInjection(this IServiceCollection services)
        {

            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            services.AddLocalization();//localization
            services.AddDistributedMemoryCache();//caching
          

            services.AddMvc()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(JsonStringLocalizerFactory));
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-SA"),
                    new CultureInfo("de-DE")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
            });
            return services;
        }
    }
}
