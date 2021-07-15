using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Web.Api.Data.Interfaces;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Controllers
{
    /**
     * 
     * TODO: 
     * Create AppServices and Azure SQL Server
     * Add SQL Server (Azure) support
     * 
     */

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoContext;
        public TodoController(ITodoRepository todoContext)
        {
            this._todoContext = todoContext;
        }

        [HttpGet]
        [Route("get/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TodoItem>))]
        public async Task<IActionResult> GetTodos(string code)
        {
            var response = await _todoContext.GetTodos(code);
            return Ok(response);
        }

        [HttpPost]
        [Route("create/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        public async Task<IActionResult> CreateTodo(string code, [FromBody] string title)
        {
            var response = await _todoContext.CreateTodo(code, title);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{code}/{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        public async Task<IActionResult> DeleteTodo(string code, long todoId)
        {
            var response = await _todoContext.DeleteTodo(code, todoId);
            return Ok(response);
        }

        [HttpPut]
        [Route("update/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        public async Task<IActionResult> UpdateTodo(string code, [FromBody] TodoItem todoItem)
        {
            var response = await _todoContext.UpdateTodo(code, todoItem);
            return Ok(response);
        }
    }
}
