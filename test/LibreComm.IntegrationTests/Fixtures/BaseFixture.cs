namespace LibreComm.IntegrationTests.Fixtures;

/// <summary>
/// Base fixture.
/// </summary>
public class BaseFixture : IAsyncLifetime
{
    public DistributedApplication App { get; private set; } = default!;

    /// <summary>
    /// Disposes fixture.
    /// </summary>
    /// <returns>Task result.</returns>
    public virtual async Task DisposeAsync()
    {
        await App.DisposeAsync();
    }

    /// <summary>
    /// Initializes fixture.
    /// </summary>
    /// <returns>Test result.</returns>
    public virtual async Task InitializeAsync()
    {
        var appHost =
            await DistributedApplicationTestingBuilder.CreateAsync<Projects.LibreComm_AppHost>();

        App = await appHost.BuildAsync();
        await App.StartAsync();
    }
}
