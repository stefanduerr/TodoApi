/////////// USING DATABASE /////////////

using System.Collections.Generic;
using System.Threading.Tasks;            //
using Microsoft.EntityFrameworkCore;    // Provides async database operations
using TodoApi.Data;                    // Allows use of TodoContext
using TodoApi.Models;                 // Allows use of TodoItem

namespace TodoApi.Services
{
    // The TodoService class provides methods to interact with the to-do items in the database.
    public class TodoService
    {
        private readonly TodoContext _context;       // Reference to the database context

        // Constructor that receives the TodoContext via dependency injection
        public TodoService(TodoContext context)
        {
            _context = context;
        }

        // Retrieves all to-do items asynchronously.
        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // Retrieves a specific to-do item by its ID asynchronously.
        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        // Adds a new to-do item to the database asynchronously.
        public async Task<TodoItem> AddAsync(TodoItem newItem)
        {
            _context.TodoItems.Add(newItem);          // Adds the new item to the context
            await _context.SaveChangesAsync();        // Saves changes to the database
            return newItem;                           // Returns the added item
        }

        // Updates an existing to-do item in the database asynchronously.
        public async Task<bool> UpdateAsync(TodoItem updatedItem)
        {
            // Checks if the item exists in the database
            if (!await _context.TodoItems.AnyAsync(t => t.Id == updatedItem.Id))
                return false;                         // Returns false if not found

            _context.Entry(updatedItem).State = EntityState.Modified; // Marks the item as modified
            await _context.SaveChangesAsync();        // Saves changes to the database
            return true;                              // Returns true to indicate success
        }

        // Deletes a to-do item from the database asynchronously.
        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id); // Finds the item by ID
            if (item == null)
                return false;                         // Returns false if not found

            _context.TodoItems.Remove(item);          // Removes the item from the context
            await _context.SaveChangesAsync();        // Saves changes to the database
            return true;                              // Returns true to indicate success
        }
    }
}



///////////// USING IN-MEMORY STORAGE ////////////////////

//using System.Collections.Generic;
//using System.Linq;
//using TodoApi.Models;

//namespace TodoApi.Services
//{
//    // The TodoService class acts as an in-memory storage for to-do items.
//    public class TodoService
//    {
//        // _todos holds all to-do items in a list.
//        private readonly List<TodoItem> _todos = new List<TodoItem>();

//        // _nextId is used to assign unique IDs to new items.
//        private int _nextId = 1;

//        // Retrieves all to-do items.
//        public List<TodoItem> GetAll() => _todos;

//        // Finds a to-do item by its ID.
//        public TodoItem? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

//        // Adds a new to-do item and assigns it a unique ID.
//        public TodoItem Add(TodoItem newItem)
//        {
//            newItem.Id = _nextId++; // Auto-increment ID
//            _todos.Add(newItem);    // Add new item to the list
//            return newItem;         // Return the newly added item
//        }

//        // Updates an existing to-do item.
//        public bool Update(TodoItem updatedItem)
//        {
//            var existingItem = GetById(updatedItem.Id);
//            if (existingItem == null) return false; // Return false if item not found

//            // Update item properties
//            existingItem.Name = updatedItem.Name;
//            existingItem.IsCompleted = updatedItem.IsCompleted;
//            existingItem.DueDate = updatedItem.DueDate;
//            return true; // Return true to indicate success
//        }

//        // Deletes a to-do item by its ID.
//        public bool Delete(int id)
//        {
//            var item = GetById(id);
//            if (item == null) return false; // Return false if item not found

//            _todos.Remove(item); // Remove item from the list
//            return true;         // Return true to indicate success
//        }
//    }
//}
