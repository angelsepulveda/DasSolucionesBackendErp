﻿namespace Membership.Modules.Features.Delete;

public class DeleteModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/modules/{Id:guid}", async (Guid Id, ISender sender) =>
            {
                await sender.Send(new DeleteModuleCommand(Id));
                
                return Results.Ok();
            })
            .WithName("DeleteModule")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete module")
            .WithDescription("Delete Module");
        
        
    }
}