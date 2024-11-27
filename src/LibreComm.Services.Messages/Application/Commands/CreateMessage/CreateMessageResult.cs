using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.Application.Commands.CreateMessage;

/// <summary>
/// CreateMessage result.
/// </summary>
/// <param name="Message">Created message.</param>
public record CreateMessageResult(MessageModel Message);
