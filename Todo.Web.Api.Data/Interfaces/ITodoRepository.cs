using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Interfaces
{
    public interface ITodoRepository
    {
        Task<ResponseMessage> CreateTodo(string code, string title);
        Task<ResponseMessage> DeleteTodo(string code, long todoId);
        Task<Response<List<TodoItem>>> GetTodos(string code);
        Task<ResponseMessage> UpdateTodo(string code, TodoItem todoItem);
    }
}