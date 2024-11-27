using LibreComm.Services.Messages.Application.Services;
using MediatR;

namespace LibreComm.Services.Messages.Application.Commands.CreateMessage;

/// <summary>
/// CreateMessage handler.
/// </summary>
/// <param name="messageService">Message service.</param>
public class CreateMessageHandler(IMessageService messageService)
    : IRequestHandler<CreateMessageCommand, CreateMessageResult>
{
    /// <summary>
    /// Handles CreateMessage command.
    /// </summary>
    /// <param name="request">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created message.</returns>
    public async Task<CreateMessageResult> Handle(
        CreateMessageCommand request,
        CancellationToken cancellationToken
    )
    {
        var message = await messageService.CreateMessageAsync(request.Message, cancellationToken);
        return new(message);
    }
}
