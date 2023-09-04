using Ardalis.Result;
using Luna.Core.Domain.Common.DTOs;
using Luna.Core.Domain.Common.Services;

namespace Luna.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public async Task<Result<TokenOutput>> GetTokenAsync(TokenInput request, string idAddress, CancellationToken cancellationToken)
        {
            await Task.Delay(400, cancellationToken);
            var result = new TokenOutput("Token", DateTime.Now, "RefreshToken", DateTime.Now);
            return Result.Success<TokenOutput>(result);
        }

        public async Task<Result<TokenOutput>> RefreshTokenAsync(RefreshTokenInput request, string idAddress)
        {
            await Task.Delay(400);
            var result = new TokenOutput("Token", DateTime.Now, "RefreshToken", DateTime.Now);
            return Result.Success<TokenOutput>(result);
        }
    }
}
