﻿using Ardalis.Result;
using Luna.Core.Domain.Common.Common.Contracts;
using Luna.Core.Domain.Common.DTOs;

namespace Luna.Core.Domain.Common.Services
{
    public interface ITokenService : ITransientService
    {
        Task<Result<TokenOutput>> GetTokenAsync(TokenInput request, string idAddress, CancellationToken cancellationToken);

        Task<Result<TokenOutput>> RefreshTokenAsync(RefreshTokenInput request, string idAddress);
    }
}
