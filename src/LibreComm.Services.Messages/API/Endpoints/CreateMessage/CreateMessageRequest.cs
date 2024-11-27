using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.API.Endpoints.CreateMessage;

/// <summary>
/// CreateMessage request.
/// </summary>
/// <param name="Message">Message.</param>
public record CreateMessageRequest(CreateMessageModel Message);
