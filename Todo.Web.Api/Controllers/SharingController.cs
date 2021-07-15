using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Web.Api.Data.Interfaces;

namespace Todo.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SharingController : ControllerBase
    {
        private readonly ISharingRepository _sharingContext;

        public SharingController(ISharingRepository sharingContext)
        {
            _sharingContext = sharingContext;
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> CreateSharingCode()
        {
            var response = await _sharingContext.CreateSharingCode();
            return Ok(response);
        }
    }
}
