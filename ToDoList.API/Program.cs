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

var app = builder.Build();

// Configure the HTTP request pipelines:

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
