using GraphQLSample.API.GraphQL;
using GraphQLSample.API.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.


// Configure GraphQL
builder.Services
    .AddGraphQLServer()
    .BindRuntimeType<long, LongAsStringType>()
    .AddQueryType<Query>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
