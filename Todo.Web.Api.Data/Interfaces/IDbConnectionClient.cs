using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Interfaces
{
    public interface IDbConnectionClient
    {
        Task<ResponseMessage> QueryResponseAsync(string name, object parameters);

        Task<Response<List<T>>> QueryMultipleResponseAsync<T>(string name, object parameters);

        Task<Response<T>> QuerySingleResponseAsync<T>(string name, object parameters);
    }
}