using Microsoft.EntityFrameworkCore;   // Provides EF Core functionalities
using TodoApi.Models;                 // Allows use of the TodoItem model

namespace TodoApi.Data
{
    // The TodoContext class manages the connection to the database.
    public class TodoContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes them to the base class.
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        // Represents the TodoItems table in the database.
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
