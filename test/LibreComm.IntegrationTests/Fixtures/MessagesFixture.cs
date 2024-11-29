namespace LibreComm.IntegrationTests.Fixtures;

/// <summary>
/// Messages fixture.
/// </summary>
public class MessagesFixture : BaseFixture, IAsyncLifetime
{
    /// <summary>
    /// Messages client.
    /// </summary>
    public HttpClient MessagesClient { get; private set; } = default!;

    public override async Task DisposeAsync()
    {
        MessagesClient.Dispose();

        await base.DisposeAsync();
    }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        MessagesClient = App.CreateHttpClient("messages-service");
    }
}
