using System.Net.Http.Json;
using FluentAssertions;
using LibreComm.IntegrationTests.Fixtures;
using LibreComm.Services.Messages.API.Endpoints.CreateMessage;
using LibreComm.Services.Messages.API.Endpoints.DeleteMessage;
using LibreComm.Services.Messages.API.Endpoints.GetMessages;

namespace LibreComm.IntegrationTests;

/// <summary>
/// Messages service tests.
/// </summary>
public class MessagesTests(MessagesFixture fixture) : IClassFixture<MessagesFixture>
{
    [Theory]
    [InlineData(
        "ec39f4e1-2c6a-433a-85c6-be3fa26bbaad",
        "9a526422-31b2-426a-95ce-cc0ebb1b9118",
        "Test content"
    )]
    public async Task SendRequestToCreateMessageEndpoint_ReturnsOkStatus(
        Guid senderId,
        Guid recipientId,
        string content
    )
    {
        var createMessageEndpointResponse = await SendRequestToCreateMessageEndpoint(
            senderId,
            recipientId,
            content
        );
        var createMessageEndpointResponseContent =
            await createMessageEndpointResponse.Content.ReadFromJsonAsync<CreateMessageResponse>();

        createMessageEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        createMessageEndpointResponseContent.Should().NotBeNull();
        createMessageEndpointResponseContent!.Message.SenderId.Should().Be(senderId);
        createMessageEndpointResponseContent!.Message.RecipientId.Should().Be(recipientId);
        createMessageEndpointResponseContent!.Message.Content.Should().Be(content);
    }

    [Theory]
    [InlineData(
        "79608f58-8b9c-404c-96a6-80eaff6ee828",
        "fc86c390-727d-49da-9b9f-e48dac0963c2",
        "Test content"
    )]
    public async Task SendRequestToDeleteMessageEndpoint_ReturnsOkStatus(
        Guid senderId,
        Guid recipientId,
        string content
    )
    {
        var createMessageEndpointResponse = await SendRequestToCreateMessageEndpoint(
            senderId,
            recipientId,
            content
        );
        var createMessageEndpointResponseContent =
            await createMessageEndpointResponse.Content.ReadFromJsonAsync<CreateMessageResponse>();

        createMessageEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        createMessageEndpointResponseContent.Should().NotBeNull();

        var deleteMessageId = createMessageEndpointResponseContent!.Message.Id;
        var deleteMessageEndpointResponse = await fixture.MessagesClient.DeleteAsync(
            $"/delete-message/{deleteMessageId}"
        );
        var deleteMessageEndpointResponseContent =
            await deleteMessageEndpointResponse.Content.ReadFromJsonAsync<DeleteMessageResponse>();

        deleteMessageEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        deleteMessageEndpointResponseContent!.Count.Should().Be(1);
    }

    [Theory]
    [InlineData(
        "1ee4def3-dfd0-4f84-b816-5b16962dd165",
        "bbbcb565-98b5-4ed8-8419-57bda70956b7",
        "Test content"
    )]
    public async Task SendRequestToGetMessages_ReturnsOkStatus(
        Guid senderId,
        Guid recipientId,
        string content
    )
    {
        var createMessageEndpointResponse = await SendRequestToCreateMessageEndpoint(
            senderId,
            recipientId,
            content
        );
        var createMessageEndpointResponseContent =
            await createMessageEndpointResponse.Content.ReadFromJsonAsync<CreateMessageResponse>();

        createMessageEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        createMessageEndpointResponseContent.Should().NotBeNull();

        var getMessagesSenderId = createMessageEndpointResponseContent!.Message.SenderId;
        var getMessagesEndpointResponse = await fixture.MessagesClient.GetAsync(
            $"/get-messages/{getMessagesSenderId}"
        );
        var getMessagesEndpointResponseContent =
            await getMessagesEndpointResponse.Content.ReadFromJsonAsync<GetMessagesResponse>();

        getMessagesEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        getMessagesEndpointResponseContent.Should().NotBeNull();
        getMessagesEndpointResponseContent!.Messages.Count().Should().Be(1);

        var getMessagesFirstObject = getMessagesEndpointResponseContent!.Messages.First();
        getMessagesFirstObject.SenderId.Should().Be(senderId);
        getMessagesFirstObject.RecipientId.Should().Be(recipientId);
        getMessagesFirstObject.Content.Should().Be(content);
    }

    [Fact]
    public async Task SendRequestToIndexEndpoint_ReturnsOkStatus()
    {
        var indexEndpointResponse = await fixture.MessagesClient.GetAsync("/");
        var indexEndpointResponseContent = await indexEndpointResponse.Content.ReadAsStringAsync();

        indexEndpointResponse.IsSuccessStatusCode.Should().BeTrue();
        indexEndpointResponseContent.Should().NotBeNullOrEmpty();
    }

    private async Task<HttpResponseMessage> SendRequestToCreateMessageEndpoint(
        Guid senderId,
        Guid recipientId,
        string content
    )
    {
        var createMessageRequest = new CreateMessageRequest(new(senderId, recipientId, content));
        var createMessageEndpointResponse = await fixture.MessagesClient.PostAsJsonAsync(
            "/create-message",
            createMessageRequest
        );

        return createMessageEndpointResponse;
    }
}
