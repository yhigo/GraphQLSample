var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GraphQL>("graphql");

builder.Build().Run();
