using Cinamaart.Persistence;
using Cinamaart.Application;
using Serilog;
using Cinamaart.WebAPI;
using System.Configuration;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Cinamaart.Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence();
builder.Services.AddApplication();
builder.Services.AddWebAPI();

builder.Host.UseSerilog((context , config) =>{
    config.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();


DataSeeder.SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*
app.MapGroup("/auth")
   .MapIdentityApi<User>();
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
