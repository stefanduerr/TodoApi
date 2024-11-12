//namespace TodoApi.Models
//{
//    // The TodoItem class represents a single to-do item.
//    public class TodoItem
//    {
//        public int Id { get; set; }               // Unique identifier for the to-do item
//        public required string Name { get; set; }          // Name or description of the to-do item
//        public bool IsCompleted { get; set; }     // Indicates if the to-do item is completed
//        public DateTime DueDate { get; set; }     // Optional due date for the to-do item
//    }
//}

using System;
using System.ComponentModel.DataAnnotations;        // Provides data annotation attributes
using System.ComponentModel.DataAnnotations.Schema; // Provides database mapping attributes

namespace TodoApi.Models
{
    // The TodoItem class represents a single to-do item in the database.
    public class TodoItem
    {
        [Key]                                        // Specifies that Id is the primary key
        public int Id { get; set; }                  // Unique identifier for the to-do item

        [Required]                                   // Name cannot be null
        public string Name { get; set; } = string.Empty; // Name or description of the to-do item

        public bool IsCompleted { get; set; }        // Indicates if the to-do item is completed

        [DataType(DataType.Date)]                    // Specifies the data type as Date
        public DateTime? DueDate { get; set; }       // Optional due date for the to-do item
    }
}

  //Explanation:
  
  //[Key]: Marks the Id property as the primary key in the database.
  //[Required]: Ensures that the Name property cannot be null.
  //string Name { get; set; } = string.Empty;: Initializes Name with an empty string to avoid null reference warnings.
  //DateTime? DueDate: The? makes the DueDate property nullable, allowing it to be null if no due date is set.