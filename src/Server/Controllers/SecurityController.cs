using Luna.Server.Contracts.Security;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json"), Consumes("application/json")]
    public class SecurityController : ControllerBase
    {
        [HttpPost(LoginEndpoint.Endpoint)]
        [ProducesResponseType(typeof(LoginEndpointResponse), 200)]
        public async Task<ActionResult<LoginEndpointResponse>> Login(LoginEndpointRequest loginEndpointRequest)
        {
            var result = new LoginEndpointResponse("Token", DateTime.Now.AddHours(10), "TokenRefresh");
            return Ok(result);
        }
    }
}
