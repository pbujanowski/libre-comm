using System.Net.Mime;
using LibreComm.Services.Messages.Application.Commands.CreateMessage;
using MediatR;

namespace LibreComm.Services.Messages.API.Endpoints.CreateMessage;

/// <summary>
/// CreateMessage endpoint.
/// </summary>
public static class CreateMessageEndpoint
{
    /// <summary>
    /// Registers CreateMessage endpoint.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Route handler builder.</returns>
    public static RouteHandlerBuilder RegisterCreateMessageEndpoint(this WebApplication app) =>
        app.MapPost(
                "/create-message",
                async (CreateMessageRequest request, IMediator mediator) =>
                {
                    var result = await mediator.Send(new CreateMessageCommand(request.Message));
                    return Results.Ok(new CreateMessageResponse(result.Message));
                }
            )
            .Accepts(
                requestType: typeof(CreateMessageRequest),
                contentType: MediaTypeNames.Application.Json
            )
            .Produces(
                statusCode: StatusCodes.Status200OK,
                responseType: typeof(CreateMessageResponse),
                contentType: MediaTypeNames.Application.Json
            )
            .WithName("CreateMessage")
            .WithDescription("CreateMessage endpoint.")
            .WithOpenApi();
}
