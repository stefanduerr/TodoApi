using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;


namespace TodoApi.Controllers
{
    // The controller defines the route and provides access to the API.
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        // Inject TodoService through the constructor
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: /api/todo - Retrieve all to-do items
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll() => _todoService.GetAll();

        // GET: /api/todo/{id} - Retrieve a specific to-do item by its ID
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var todo = _todoService.GetById(id);
            //Console.WriteLine('Searching for Item...');
            return todo == null ? NotFound() : Ok(todo); // Return 404 if not found
        }

        // POST: /api/todo - Add a new to-do item
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem newItem)
        {
            // Add the new item to the service
            var createdItem = _todoService.Add(newItem);

            // Return a 201 Created response, with the URI of the new resource and the item itself
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }


        // PUT: /api/todo/{id} - Update an existing to-do item by ID
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updatedItem)
        {
            if (id != updatedItem.Id) return BadRequest(); // Return 400 if IDs don't match

            return _todoService.Update(updatedItem) ? NoContent() : NotFound(); // Return 404 if not found
        }

        // DELETE: /api/todo/{id} - Delete a to-do item by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _todoService.Delete(id) ? NoContent() : NotFound(); // Return 404 if not found
        }
    }
}
