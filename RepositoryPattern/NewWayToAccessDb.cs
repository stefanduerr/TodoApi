using TodoApi.Models;

namespace TodoApi.RepositoryPattern
{
    public class NewWayToAccessDb : ITodoItemRepository
    {
        public Task<TodoItem> AddAsync(TodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllAsync()
        {
            return Task.FromResult(new List<TodoItem>
            {
                new TodoItem
                {
                    Id = 0,
                    Name = "Test",
                    IsCompleted = false,
                    DueDate = DateTime.Now
                }
            });
        }


        public Task<TodoItem?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TodoItem updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
