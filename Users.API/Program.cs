using Users.Infrastructure;
using Users.Application;
using Carter;
using Users.API.Infrastructure;
using Users.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration)
    .RegisterApplication()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCarter()
    .AddProblemDetails()
    .AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var databaseInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();
app.Run();


