using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Web.Api.Data.Interfaces;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Repositories
{
    public class TodoSqlServerRepository : ITodoRepository
    {
        private IDbConnectionClient _connectionClient { get; set; }

        public TodoSqlServerRepository(IDbConnectionClient connectionClient)
        {
            _connectionClient = connectionClient;
        }

        public async Task<ResponseMessage> CreateTodo(string code, string title)
        {
            return await _connectionClient.QueryResponseAsync("dbp_create_todo", new { @code = code, @title = title });
        }

        public async Task<ResponseMessage> DeleteTodo(string code, long todoId)
        {
            return await _connectionClient.QueryResponseAsync("dbp_delete_todo", new { @id = todoId, @code = code });
        }

        public async Task<Response<List<TodoItem>>> GetTodos(string code)
        {
            return await _connectionClient.QueryMultipleResponseAsync<TodoItem>("dbp_get_todos", new { @code = code });
        }

        public async Task<ResponseMessage> UpdateTodo(string code, TodoItem todoItem)
        {
            return await _connectionClient.QueryResponseAsync("dbp_update_todo", new { @code = code, @id = todoItem.Id, @title = todoItem.Title, @state = todoItem.State });
        }
    }
}
