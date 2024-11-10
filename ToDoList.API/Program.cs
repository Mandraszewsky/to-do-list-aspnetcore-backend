using ToDoList.API;
using ToDoList.Application;
using ToDoList.Infrastructure;
using ToDoList.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register services:

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipelines:

app.UseApiServices();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
