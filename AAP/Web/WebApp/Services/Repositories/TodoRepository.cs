using System.Text.Json.Serialization;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services.Repositories
{
    public class TodoRepository(IHttpClientService http)
        : ITodoRepository
    {
        public async Task<Guid> AddAsync(
            string name,
            bool isDone,
            DateTime createdDate,
            DateTime updatedDate)
        {
            var result = await http.PostAsync<Guid>("Todo",
                new Todo
                {
                    Name = name,
                    IsDone = isDone,
                    StartDate = createdDate,
                    EndDate = updatedDate
                });
            return result;
        }

        public async Task<IEnumerable<TodoWrapper>?> GetAllAsync()
        {
            var result = await http.GetAsync<IEnumerable<TodoWrapper>>("Todo");
            return null;
        }

        public async Task<TodoWrapper?> GetByIdAsync(Guid id)
        {
            var result = await http.GetAsync<TodoWrapper?>($"Todo/{id}");
            return result;
        }

        public async Task<bool> UpdateAsync(Todo item)
        {
            var result = await http.PutAsync<bool>("Todo", item);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await http.DeleteAsync<bool>($"Todo/{id}");
            return result;
        }
    }
}
