using TodoApi.Models;

namespace TodoApi.RepositoryPattern
{
    public interface ITodoItemRepository
    {
        // Retrieves all to-do items asynchronously.
        Task<List<TodoItem>> GetAllAsync();

        // Retrieves a specific to-do item by its ID asynchronously.
        Task<TodoItem?> GetByIdAsync(int id);

        // Adds a new to-do item to the database asynchronously.
        Task<TodoItem> AddAsync(TodoItem newItem);

        // Updates an existing to-do item in the database asynchronously.
        Task<bool> UpdateAsync(TodoItem updatedItem);

        // Deletes a to-do item from the database asynchronously by ID.
        Task<bool> DeleteAsync(int id);
    }
}
