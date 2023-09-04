using Luna.Server.Contracts.Security;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json"), Consumes("application/json")]
    public class SecurityController : ControllerBase
    {
        [HttpPost(TokenEndpoint.Endpoint)]
        [ProducesResponseType(typeof(TokenEndpointResponse), 200)]
        public async Task<ActionResult<TokenEndpointResponse>> Login(TokenEndpointRequest tokenEndpointRequest)
        {
            await Task.Delay(200);
            var result = new TokenEndpointResponse("Token", DateTime.Now.AddHours(10), "TokenRefresh");
            return Ok(result);
        }
    }
}
