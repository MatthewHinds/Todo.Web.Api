using System.Threading.Tasks;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.Interfaces
{
    public interface ISharingRepository
    {
        Task<Response<SharingCode>> CreateSharingCode();
    }
}