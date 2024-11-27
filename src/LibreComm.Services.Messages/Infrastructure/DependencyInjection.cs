using System.Reflection;
using LibreComm.Services.Messages.Application.Services;
using LibreComm.Services.Messages.Infrastructure.Services;

namespace LibreComm.Services.Messages.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure to services.
    /// </summary>
    /// <param name="builder">Host application builder.</param>
    /// <returns>Host application builder.</returns>
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        builder.AddMongoDBClient("messages-database");

        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

        builder.Services.AddSingleton<IMessageService, MessageService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    /// <summary>
    /// Add infrastructure to web application.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Web application.</returns>
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}
