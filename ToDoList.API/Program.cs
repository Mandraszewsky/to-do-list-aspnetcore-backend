using ToDoList.API;
using ToDoList.Application;
using ToDoList.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register services:

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();



app.Run();
