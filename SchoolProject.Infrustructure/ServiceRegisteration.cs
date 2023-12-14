
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.ModelsHelper;
using SchoolProject.Infrustructure.Context;
using System.Text;

namespace SchoolProject.Infrustructure
{
    public static class ServiceRegisteration
    {

        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddIdentity<User, IdentityRole<int>>(o => { }).AddEntityFrameworkStores<AppDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedEmail = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;


            });
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.Cookie.Name = "YourAppCookieName";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    // ReturnUrlParameter requires 
            //    //using Microsoft.AspNetCore.Authentication.Cookies;
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});


            //JWT Authentication
            var jwtsettings = new JwtSettings();
           

           configuration.GetSection(nameof(jwtsettings)).Bind(jwtsettings);

            services.AddSingleton(jwtsettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                     {
                         options.RequireHttpsMetadata = false;
                         options.SaveToken = true;
                        
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = jwtsettings.ValidateIssure,
                             ValidateAudience = jwtsettings.ValidateAudience,
                             ValidateLifetime = jwtsettings.ValidateLifetime,
                             ValidateIssuerSigningKey = jwtsettings.ValidateIssuerSigningKey,
                             ValidIssuer = jwtsettings.Issuer,
                             ValidAudience = jwtsettings.Audience,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtsettings.Secret))
                         };
                    });
            //Jwt configuration ends here

            //services.AddAuthentication(options =>
            //{

            //    // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //    // options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    // options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //});
            // //.AddJwtBearer(options =>
            // //   {

            // //   })

            // //.AddCookie(options =>
            // //   {
            // //       // Cookie settings
            // //       options.Cookie.HttpOnly = true;
            // //       options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            // //       options.LoginPath = "/Identity/Account/Login";
            // //       options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            // //       options.SlidingExpiration = true;
            // //   });

            return services;
        }

    }
}
