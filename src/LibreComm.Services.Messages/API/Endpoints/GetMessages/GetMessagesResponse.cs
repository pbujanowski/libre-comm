using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.API.Endpoints.GetMessages;

/// <summary>
/// GetMessages response.
/// </summary>
/// <param name="Messages">Messages.</param>
public record GetMessagesResponse(IEnumerable<MessageModel> Messages);
