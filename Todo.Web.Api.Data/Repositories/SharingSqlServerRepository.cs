using System.Threading.Tasks;
using Todo.Web.Api.Data.Interfaces;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Repositories
{
    public class SharingSqlServerRepository : ISharingRepository
    {
        private IDbConnectionClient _connectionClient { get; set; }

        public SharingSqlServerRepository(IDbConnectionClient connectionClient)
        {
            _connectionClient = connectionClient;
        }

        public async Task<Response<SharingCode>> CreateSharingCode()
        {
            var response = await _connectionClient.QuerySingleResponseAsync<SharingCode>("dbp_create_sharing_code", new { });
            return response;
        }
    }
}
