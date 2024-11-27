using LibreComm.Services.Common.Application.Models;
using MediatR;

namespace LibreComm.Services.Messages.Application.Commands.CreateMessage;

/// <summary>
/// CreateMessage command.
/// </summary>
/// <param name="Message">Message.</param>
public record CreateMessageCommand(CreateMessageModel Message) : IRequest<CreateMessageResult>;
