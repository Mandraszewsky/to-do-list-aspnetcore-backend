using Carter;
using MediatR;
using ToDoList.Application.CQRS.Tasks.Commands.DeleteTask;

namespace ToDoList.API.Endpoints;

public class DeleteTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteTaskCommand(Id));

            return Results.Ok(result);
        })
        .WithName("DeleteTask")
        .Produces<DeleteTaskResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Task")
        .WithDescription("Delete Task");
    }
}