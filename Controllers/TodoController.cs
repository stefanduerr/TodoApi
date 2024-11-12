///////////// DATABASE ///////////

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;                 // Allows use of TodoItem
using TodoApi.Services;              // Allows use of TodoService


namespace TodoApi.Controllers
{
    // Specifies the route pattern for the controller
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;   // Reference to the TodoService

        // Constructor that receives the TodoService via dependency injection
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: /api/todo - Retrieves all to-do items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            var todos = await _todoService.GetAllAsync();  // Gets all to-do items
            return Ok(todos);                              // Returns the items with 200 OK
        }

        // GET: /api/todo/{id} - Retrieves a specific to-do item by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var todo = await _todoService.GetByIdAsync(id); // Gets the to-do item by ID
            return todo == null ? NotFound() : Ok(todo);    // Returns 404 if not found
        }

        // POST: /api/todo - Adds a new to-do item
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem newItem)
        {
            var createdItem = await _todoService.AddAsync(newItem); // Adds the new item
            // Returns 201 Created with the route to access the new item
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        // PUT: /api/todo/{id} - Updates an existing to-do item by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem updatedItem)
        {
            if (id != updatedItem.Id)
                return BadRequest();                        // Returns 400 Bad Request if IDs don't match

            var success = await _todoService.UpdateAsync(updatedItem); // Updates the item
            return success ? NoContent() : NotFound();       // Returns 204 No Content if successful
        }

        // DELETE: /api/todo/{id} - Deletes a to-do item by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _todoService.DeleteAsync(id); // Deletes the item
            return success ? NoContent() : NotFound();       // Returns 204 No Content if successful
        }
    }
}


////// IN-MEMORY /////////

//using Microsoft.AspNetCore.Mvc;
//using TodoApi.Models;
//using TodoApi.Services;

//namespace TodoApi.Controllers
//{
//    // The controller defines the route and provides access to the API.
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TodoController : ControllerBase
//    {
//        private readonly TodoService _todoService;

//        // Inject TodoService through the constructor
//        public TodoController(TodoService todoService)
//        {
//            _todoService = todoService;
//        }

//        // GET: /api/todo - Retrieve all to-do items
//        [HttpGet]
//        public ActionResult<IEnumerable<TodoItem>> GetAll() => _todoService.GetAll();

//        // GET: /api/todo/{id} - Retrieve a specific to-do item by its ID
//        [HttpGet("{id}")]
//        public ActionResult<TodoItem> GetById(int id)
//        {
//            var todo = _todoService.GetById(id);
//            //Console.WriteLine('Searching for Item...');
//            return todo == null ? NotFound() : Ok(todo); // Return 404 if not found
//        }

//        // POST: /api/todo - Add a new to-do item
//        [HttpPost]
//        public ActionResult<TodoItem> Create(TodoItem newItem)
//        {
//            // Add the new item to the service
//            var createdItem = _todoService.Add(newItem);

//            // Return a 201 Created response, with the URI of the new resource and the item itself
//            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
//        }


//        // PUT: /api/todo/{id} - Update an existing to-do item by ID
//        [HttpPut("{id}")]
//        public IActionResult Update(int id, TodoItem updatedItem)
//        {
//            if (id != updatedItem.Id) return BadRequest(); // Return 400 if IDs don't match

//            return _todoService.Update(updatedItem) ? NoContent() : NotFound(); // Return 404 if not found
//        }

//        // DELETE: /api/todo/{id} - Delete a to-do item by ID
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            return _todoService.Delete(id) ? NoContent() : NotFound(); // Return 404 if not found
//        }
//    }
//}
