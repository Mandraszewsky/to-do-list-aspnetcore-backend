using Carter;
using MediatR;
using ToDoList.Application.CQRS.Tasks.Commands.UpdateTask;

namespace ToDoList.API.Endpoints;

public class UpdateTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateTaskCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return Results.Ok(result);
        })
        .WithName("UpdateTask")
        .Produces<UpdateTaskResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Task")
        .WithDescription("Update Task");
    }
}