using Core;
using DataAccess.InMemory;
using Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDataAccess()
    .AddPresentation();

WebApplication app = builder.Build();

app.MapControllers();

app.Run();
