using Carter;
using MediatR;
using ToDoList.Application.Tasks.Commands.CreateTask;

namespace ToDoList.API.Endpoints;


public class CreateTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateTaskCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return Results.Created($"/orders/{result.Id}", result);
        })
        .WithName("CreateTask")
        .Produces<CreateTaskResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Task")
        .WithDescription("Create Task");
    }
}