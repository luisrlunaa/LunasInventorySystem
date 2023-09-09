namespace Luna.Core.Domain.Common.DTOs
{
    public record TokenInput(string Email, string Password);
    public record RefreshTokenInput(string Email, string Password);
    public record TokenOutput(string Token, DateTime TokenExpiryTime, string RefreshToken, DateTime RefreshTokenExpiryTime);
}
