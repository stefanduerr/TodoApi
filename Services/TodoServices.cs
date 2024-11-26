/////////// USING DATABASE /////////////

using System.Collections.Generic;
using System.Threading.Tasks;           
using Microsoft.EntityFrameworkCore;   // Provides async database operations
using TodoApi.Data;                    // Allows use of TodoContext
using TodoApi.Models;
using TodoApi.RepositoryPattern;                  // Allows use of TodoItem

namespace TodoApi.Services
{
    // The TodoService class provides methods to interact with the to-do items in the database.
    public class TodoService
    {
        // Reference to the repository pattern that contains the database context
        // I'm not bringing the actual class, I'm bringing an interface to reduce dependencies
        private readonly ITodoItemRepository _repository;

        // Constructor that receives the TodoContext via dependency injection
        public TodoService(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        // Retrieves all to-do items asynchronously.
        public Task<List<TodoItem>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        // Retrieves a specific to-do item by its ID asynchronously.
        public Task<TodoItem?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        // Adds a new to-do item to the database asynchronously.
        public Task<TodoItem> AddAsync(TodoItem newItem)
        {
            return _repository.AddAsync(newItem);
        }

        // Updates an existing to-do item in the database asynchronously.
        public Task<bool> UpdateAsync(TodoItem updatedItem)
        {
            return _repository.UpdateAsync(updatedItem);
        }

        // Deletes a to-do item from the database asynchronously.
        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);                          // Returns true to indicate success
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
