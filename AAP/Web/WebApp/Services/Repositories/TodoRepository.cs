
namespace WebApp.Services.Repositories;

public class TodoRepository(IHttpClientService http)
    : ITodoRepository
{
    public async Task<Guid> AddAsync(
        string name,
        bool isDone,
        DateTime createdDate,
        DateTime updatedDate)
    {
        var result = await http.PostAsync<CreateTodo>("Todo",
            new Todo
            {
                Name = name,
                IsDone = isDone,
                StartDate = createdDate,
                EndDate = updatedDate
            });
        return result.id;
    }

    public async Task<TodoList> GetAllAsync()
    {
        var result = await http.GetAsync<TodoList>("Todo");
        return result;
    }

    public async Task<TodoWrapper?> GetByIdAsync(Guid id)
    {
        var result = await http.GetAsync<TodoWrapper?>($"Todo/{id}");
        return result;
    }

    public async Task<UpdateTodo> UpdateAsync(Todo item)
    {
        var result = await http.PutAsync<UpdateTodo>("Todo", item);
        return result;
    }

    public async Task<DeleteTodo> DeleteAsync(Guid id)
    {
        var result = await http.DeleteAsync<DeleteTodo>($"Todo/{id}");
        return result;
    }

}
