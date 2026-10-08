using Example.Api.Features.Todos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterTodosFeatureDependencies();

var app = builder.Build();

app.UseHttpsRedirection();

app.RegisterTodosFeature();

app.Run();
