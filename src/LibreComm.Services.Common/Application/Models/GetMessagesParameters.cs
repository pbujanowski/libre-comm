namespace LibreComm.Services.Common.Application.Models;

/// <summary>
/// GetMessages parameters.
/// </summary>
/// <param name="SenderId">Sender ID.</param>
public record GetMessagesParameters(Guid SenderId);
