var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BG>("bg");

builder.Build().Run();
