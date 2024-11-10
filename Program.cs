using Microsoft.AspNetCore.Builder; // Provides classes for building the web application
using Microsoft.Extensions.DependencyInjection; // Contains extensions for dependency injection
using Microsoft.Extensions.Hosting; // Provides interfaces for hosting the application
using TodoApi.Services;

/// APP CONFIG
var builder = WebApplication.CreateBuilder(args); // Creates a new builder object for configuring the app

// Add services to the container.

// Adds support for controllers, which are used to create a structured API with MVC (Model-View-Controller)
builder.Services.AddControllers();

// Register TodoService as a singleton to persist data across requests
builder.Services.AddSingleton<TodoService>();

// Adds support for automatically generating API documentation using Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// APP BUILD
var app = builder.Build(); // Builds the application based on the configuration set above

// Configure the HTTP request pipeline.

// Checks if the app is running in development mode
if (app.Environment.IsDevelopment())
{
    // Enables Swagger and Swagger UI (documentation interface) if in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enforces HTTPS (Secure HTTP) redirection for all requests, redirecting HTTP to HTTPS
app.UseHttpsRedirection();

// Adds middleware to handle authorization (even if not fully configured, it’s set up for future use)
app.UseAuthorization();

// Maps controller routes to handle incoming requests for API endpoints defined in controllers
app.MapControllers();

app.Run(); // Runs the application, starting the request handling loop



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}