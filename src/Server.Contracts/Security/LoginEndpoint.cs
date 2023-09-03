namespace Luna.Server.Contracts.Security
{
    public record LoginEndpointRequest(string Username, string Password);
    public record LoginEndpointResponse(string Token, DateTime ExpirationDate, string TokenRefresh);
    public static class LoginEndpoint
    {
        public const string Endpoint = "/api/Security/Login";
    }
}
