using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure;
using SchoolProject.Service;
using SchoolProject.Core;

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
    .LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);
});

//Dependency injection
builder.Services.AddInfrustructureDependencyInjection()
                .AddServiceDependencyInjection()
                .AddModuleCoreDependencyInjection();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
