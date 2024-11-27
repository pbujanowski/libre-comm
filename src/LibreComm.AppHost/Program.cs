var builder = DistributedApplication.CreateBuilder(args);

var messagesMongoDB = builder.AddMongoDB("messages-mongodb");
var messagesDatabase = messagesMongoDB.AddDatabase("messages-database");

builder
    .AddProject<Projects.LibreComm_Services_Messages>("messages-service")
    .WithReference(messagesDatabase);

builder.Build().Run();
