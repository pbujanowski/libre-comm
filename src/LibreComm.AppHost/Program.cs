var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.LibreComm_Services_Messages>("messages-service");

builder.Build().Run();
