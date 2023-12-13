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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection SQL
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});
builder.Services.AddIdentity<User, IdentityRole<int>>(o => { }).AddEntityFrameworkStores<AppDbContext>();




//Dependency injection
builder.Services.AddInfrustructureDependencyInjection()
                .AddServiceDependencyInjection()
                .AddModuleCoreDependencyInjection()
                .AddServiceRegisteration(builder.Configuration)
                .AddLocalizationLanguageDependencyInjection();

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
var app = builder.Build();

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
app.UseMiddleware<ErrorHandlerMiddleware>();






app.Run();
