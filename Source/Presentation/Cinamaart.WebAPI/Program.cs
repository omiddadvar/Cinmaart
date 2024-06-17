using Cinamaart.Persistence;
using Cinamaart.Application;
using Serilog;
using Cinamaart.WebAPI;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddWebAPI();

builder.Host.UseSerilog((context , config) =>{
    config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddDbContext<MainDBContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection" ,
                        b => b.MigrationsAssembly(typeof(Program).Assembly.GetName().Name)));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
