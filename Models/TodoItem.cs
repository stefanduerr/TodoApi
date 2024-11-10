namespace TodoApi.Models
{
    // The TodoItem class represents a single to-do item.
    public class TodoItem
    {
        public int Id { get; set; }               // Unique identifier for the to-do item
        public required string Name { get; set; }          // Name or description of the to-do item
        public bool IsCompleted { get; set; }     // Indicates if the to-do item is completed
        public DateTime DueDate { get; set; }     // Optional due date for the to-do item
    }
}
