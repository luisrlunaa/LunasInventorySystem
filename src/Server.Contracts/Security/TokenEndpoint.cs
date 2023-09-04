namespace Luna.Server.Contracts.Security
{
    public record TokenEndpointRequest(string Username, string Password);
    public record TokenEndpointResponse(string Token, DateTime ExpirationDate, string TokenRefresh);
    public static class TokenEndpoint
    {
        public const string Endpoint = "/api/Security/Login";
    }
}
