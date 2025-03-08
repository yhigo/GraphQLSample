var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GraphQLSample_API>("graphqlapi");

builder.Build().Run();
