using LibreComm.Services.Messages.Application.Services;
using MediatR;

namespace LibreComm.Services.Messages.Application.DeleteMessage;

/// <summary>
/// DeleteMessage handler.
/// </summary>
/// <param name="messageService">Message service.</param>
public class DeleteMessageHandler(IMessageService messageService)
    : IRequestHandler<DeleteMessageCommand, DeleteMessageResult>
{
    /// <summary>
    /// Handles DeleteMessage command.
    /// </summary>
    /// <param name="request">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deleted message.</returns>
    public async Task<DeleteMessageResult> Handle(
        DeleteMessageCommand request,
        CancellationToken cancellationToken
    )
    {
        var message = await messageService.DeleteMessageAsync(request.Message, cancellationToken);
        return new(message);
    }
}
