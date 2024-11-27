using LibreComm.ServiceDefaults;
using LibreComm.Services.Messages.API;
using LibreComm.Services.Messages.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddInfrastructure();

var app = builder.Build();

app.UseInfrastructure();

app.UseAPI();

app.Run();
