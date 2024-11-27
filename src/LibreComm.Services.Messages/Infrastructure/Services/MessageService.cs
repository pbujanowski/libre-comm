using LibreComm.Services.Common.Application.Models;
using LibreComm.Services.Messages.Application.Services;
using LibreComm.Services.Messages.Domain.Entities;
using MongoDB.Driver;

namespace LibreComm.Services.Messages.Infrastructure.Services;

/// <summary>
/// Message service.
/// </summary>
/// <param name="mongoClient">MongoDB client.</param>
public class MessageService(IMongoClient mongoClient) : IMessageService
{
    /// <summary>
    /// Messages field.
    /// </summary>
    private readonly IMongoCollection<Message> _messages = mongoClient
        .GetDatabase("messages-database")
        .GetCollection<Message>("messages");

    /// <inheritdoc />
    public async Task<MessageModel> CreateMessageAsync(
        CreateMessageModel message,
        CancellationToken cancellationToken = default
    )
    {
        var messageToCreate = new Message
        {
            CreatedAt = DateTimeOffset.UtcNow,
            SenderId = message.SenderId,
            RecipientId = message.RecipientId,
            Content = message.Content,
        };

        await _messages.InsertOneAsync(messageToCreate, new InsertOneOptions(), cancellationToken);

        return new(
            messageToCreate.Id,
            messageToCreate.CreatedAt,
            messageToCreate.UpdatedAt,
            messageToCreate.SenderId,
            messageToCreate.RecipientId,
            messageToCreate.Content
        );
    }

    /// <inheritdoc />
    public async Task<long> DeleteMessageAsync(
        DeleteMessageModel message,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _messages.DeleteOneAsync(e => e.Id == message.Id, cancellationToken);
        return result.DeletedCount;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<MessageModel>> GetMessagesAsync(
        GetMessagesParameters parameters,
        CancellationToken cancellationToken = default
    )
    {
        var foundMessages = new List<MessageModel>();
        await _messages
            .Find(e => e.SenderId == parameters.SenderId)
            .ForEachAsync(
                (message) =>
                    foundMessages.Add(
                        new(
                            message.Id,
                            message.CreatedAt,
                            message.UpdatedAt,
                            message.SenderId,
                            message.RecipientId,
                            message.Content
                        )
                    ),
                cancellationToken
            );

        return foundMessages;
    }
}
