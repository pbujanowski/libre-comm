using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.API.Endpoints.CreateMessage;

/// <summary>
/// CreateMessage response.
/// </summary>
/// <param name="Message">Message.</param>
public record CreateMessageResponse(MessageModel Message);
