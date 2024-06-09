using Cinamaart.Presentation;
using Cinamaart.Persistence;
using Cinamaart.Application;
using Serilog;
using Cinamaart.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddWebAPI();

builder.Host.UseSerilog((context , config) =>{
    config.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
