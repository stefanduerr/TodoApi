using Microsoft.EntityFrameworkCore;      // Provides database functionalities
using TodoApi.Data;                      // Allows use of TodoContext
using TodoApi.RepositoryPattern;
using TodoApi.Services;                 // Allows use of TodoService

var builder = WebApplication.CreateBuilder(args); // Creates the builder for the app

// Add services to the container.

// Registers the controllers for dependency injection
builder.Services.AddControllers();

// Registers the TodoContext with SQLite as the database provider
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite("Data Source=Todo.db"));    // Specifies the SQLite database file

// Registers the TodoService for dependency injection
builder.Services.AddScoped<TodoService>();

// TodoItemRepo Dependency Injection
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
//builder.Services.AddScoped<ITodoItemRepository, NewWayToAccessDb>();


// Registers Swagger services for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();                        // Builds the app

// Configures the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Running on development server.");
    app.UseSwagger();                             // Enables Swagger in development
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();                        // Redirects HTTP requests to HTTPS

app.UseAuthorization();                           // Adds authorization middleware

app.MapControllers();                             // Maps controller routes

app.Run();                                        // Runs the application



////////////////////////// IN - MEMORY

//using Microsoft.AspNetCore.Builder; // Provides classes for building the web application
//using Microsoft.Extensions.DependencyInjection; // Contains extensions for dependency injection
//using Microsoft.Extensions.Hosting; // Provides interfaces for hosting the application
//using TodoApi.Services;

///// APP CONFIG
//var builder = WebApplication.CreateBuilder(args); // Creates a new builder object for configuring the app

//// Add services to the container.

//// Adds support for controllers, which are used to create a structured API with MVC (Model-View-Controller)
//builder.Services.AddControllers();

//// Register TodoService as a singleton to persist data across requests
//builder.Services.AddSingleton<TodoService>();

//// Adds support for automatically generating API documentation using Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

///// APP BUILD
//var app = builder.Build(); // Builds the application based on the configuration set above

//// Configure the HTTP request pipeline.

//// Checks if the app is running in development mode
//if (app.Environment.IsDevelopment())
//{
//    // Enables Swagger and Swagger UI (documentation interface) if in development mode
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Enforces HTTPS (Secure HTTP) redirection for all requests, redirecting HTTP to HTTPS
//app.UseHttpsRedirection();

//// Adds middleware to handle authorization (even if not fully configured, it’s set up for future use)
//app.UseAuthorization();

//// Maps controller routes to handle incoming requests for API endpoints defined in controllers
//app.MapControllers();

//app.Run(); // Runs the application, starting the request handling loop
