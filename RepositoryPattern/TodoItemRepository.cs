using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.RepositoryPattern
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _todoContext;
        public TodoItemRepository(TodoContext todoContext) 
        { 
            _todoContext = todoContext;
        }
        public async Task<TodoItem> AddAsync(TodoItem newItem)
        {
            _todoContext.TodoItems.Add(newItem); // Add the new item to the context
            await _todoContext.SaveChangesAsync(); // Save changes to the database
            return newItem; // Return the added item
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _todoContext.TodoItems.FindAsync(id); // Find the item by ID
            if (item == null)
                return false; // Return false if the item is not found

            _todoContext.TodoItems.Remove(item); // Remove the item from the context
            await _todoContext.SaveChangesAsync(); // Save changes to the database
            return true; // Return true to indicate successful deletion
        }

        public Task<List<TodoItem>> GetAllAsync()
        {
            return _todoContext.TodoItems.ToListAsync(); // Return all items asynchronously
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _todoContext.TodoItems.FindAsync(id); // Find and return the item by ID
        }

        public async Task<bool> UpdateAsync(TodoItem updatedItem)
        {
            var exists = await _todoContext.TodoItems.AnyAsync(t => t.Id == updatedItem.Id); // Check if the item exists
            if (!exists)
                return false; // Return false if the item does not exist

            _todoContext.Entry(updatedItem).State = EntityState.Modified; // Mark the item as modified
            await _todoContext.SaveChangesAsync(); // Save changes to the database
            return true; // Return true to indicate successful update
        }
    }
}
