using LocalizationLanguage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Service;

using JsonBasedLocalization.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;
using SchoolProject.Infrustructure.Seeding;
using SchoolProject.Core.Filters;
using Microsoft.AspNetCore.Authorization;
using SchoolProject.Core.policy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(op =>
{
    op.Filters.Add<PermissionBasedAuthorizationFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection SQL
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});

builder.Services.AddIdentity<User, Role>(o => { }).AddEntityFrameworkStores<AppDbContext>();

//Register Filter
//builder.Services.AddTransient<AuthRolesFilter>();


//Dependency injection
 builder.Services.AddInfrustructureDependencyInjectionAsync().Result
                .AddServiceDependencyInjection()
                .AddModuleCoreDependencyInjection()
                .AddServiceRegisteration(builder.Configuration)
                .AddLocalizationLanguageDependencyInjection();//localization

//Cors service
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "Cors_service", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

//AddSwaggerGen
builder.Services.AddSwaggerGen(opt =>
{
    opt.EnableAnnotations();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "School", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});



var app = builder.Build();

////Data Seeding
//using(var scop=app.Services.CreateScope())
//{
//    var rolemanager = scop.ServiceProvider.GetRequiredService<RoleManager<Role>>();
//    var usermanager=scop.ServiceProvider.GetRequiredService<UserManager<User>>();
//    var dbcontext = scop.ServiceProvider.GetRequiredService<AppDbContext>();
//    //var dbcontext2 = scop.ServiceProvider.GetService<AppDbContext>();
//    await RoleSeeding.SeedRoleAddAsync(rolemanager);
//    await  UserSeeding.SeedSuperAdminUserAsync(usermanager,rolemanager, dbcontext);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region localization
//localization
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options!.Value);

app.UseRequestCulture();//localization extension
#endregion
app.UseHttpsRedirection();

app.UseCors("Cors_service");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();//global Exception
app.Run();
