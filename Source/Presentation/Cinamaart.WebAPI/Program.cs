using Cinamaart.Application;
using Cinamaart.Persistence;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Extentions;
using Cinamaart.WebAPI;
using Microsoft.Extensions.Options;
using Cinamaart.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddWebAPI();

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //await app.MigrateDebugDatabase();
}

app.SeedData();

app.UseExceptionHandler();


var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

/*
app.MapGroup("/auth")
   .MapIdentityApi<User>();
*/
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
