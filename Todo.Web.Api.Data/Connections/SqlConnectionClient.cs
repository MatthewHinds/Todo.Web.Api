using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Api.Data.Interfaces;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Connections
{
    public class SqlConnectionClient : IDbConnectionClient
    {
        private string _connectionString { get; set; }
        private readonly IOptions<ConnectionStrings> _options;

        public SqlConnectionClient(IOptions<ConnectionStrings> options)
        {
            _options = options;
            _connectionString = _options.Value.SqlServer;
        }

        public async Task<ResponseMessage> QueryResponseAsync(string name, object parameters)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandDefinition = new CommandDefinition(name, parameters, commandType: CommandType.StoredProcedure);
                    var response = await sqlConnection.QueryFirstAsync<ResponseMessage>(commandDefinition);

                    return response;
                }
            }
            catch (Exception ex)
            {
                return new ResponseMessage().CreateErrorResponse($"{nameof(QueryResponseAsync)} - {ex.Message}");
            }
        }

        public async Task<Response<List<T>>> QueryMultipleResponseAsync<T>(string name, object parameters)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandDefinition = new CommandDefinition(name, parameters, commandType: CommandType.StoredProcedure);
                    var multiple = await sqlConnection.QueryMultipleAsync(commandDefinition);

                    var response = new Response<List<T>>()
                    {
                        Data = multiple.Read<T>().ToList(),
                        Message = multiple.Read<ResponseMessage>().First()
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                return new Response<List<T>>()
                {
                    Message = new ResponseMessage().CreateErrorResponse($"{nameof(QueryMultipleResponseAsync)} - {ex.Message}")
                };
            }
        }

        public async Task<Response<T>> QuerySingleResponseAsync<T>(string name, object parameters)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandDefinition = new CommandDefinition(name, parameters, commandType: CommandType.StoredProcedure);
                    var multiple = await sqlConnection.QueryMultipleAsync(commandDefinition);

                    var response = new Response<T>()
                    {
                        Data = multiple.Read<T>().FirstOrDefault(),
                        Message = multiple.Read<ResponseMessage>().First()
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                return new Response<T>()
                {
                    Message = new ResponseMessage().CreateErrorResponse($"{nameof(QuerySingleResponseAsync)} - {ex.Message}")
                };
            }
        }
    }
}
