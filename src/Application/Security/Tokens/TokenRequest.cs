using Ardalis.Result;
using FluentValidation;
using Luna.Core.Application.Common.Validation;
using Luna.Core.Domain.Common.DTOs;
using Luna.Core.Domain.Common.Services;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Luna.Core.Application.Security.Tokens;
public record TokenRequest(string Email, string Password) : IRequest<Result<TokenResponse>>;
public record TokenResponse(string Token, DateTime TokenExpiryTime, string RefreshToken, DateTime RefreshTokenExpiryTime);

public class TokenRequestHandler : IRequestHandler<TokenRequest, Result<TokenResponse>>
{
    public ITokenService TokenService { get; }
    public IUserInternetProtocolAddressService UserInternetProtocolAddressService { get; }

    public TokenRequestHandler(ITokenService tokenService, IUserInternetProtocolAddressService userInternetProtocolAddressService)
    {
        TokenService = tokenService;
        UserInternetProtocolAddressService = userInternetProtocolAddressService;
    }

    public async Task<Result<TokenResponse>> Handle(TokenRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var input = new TokenInput(request.Email, request.Password);
        var getTokenOutput = await TokenService.GetTokenAsync(input, UserInternetProtocolAddressService.IdAddress, cancellationToken);
        if (!getTokenOutput.IsSuccess)
        {
            return Result<TokenResponse>.Error(getTokenOutput.Errors.ToArray());
        }

        var tokenOutput = getTokenOutput.Value;
        var tokenResult = new TokenResponse(tokenOutput.Token, tokenOutput.TokenExpiryTime, tokenOutput.RefreshToken,
            tokenOutput.RefreshTokenExpiryTime);
        var result = Result<TokenResponse>.Success(tokenResult);
        return result;
    }
}

public class TokenRequestValid : CustomValid<TokenRequest>
{
    public TokenRequestValid(IStringLocalizer<TokenRequestValid> T)
    {
        if (T == null)
        {
            throw new ArgumentNullException(nameof(T));
        }

        RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(T["Invalid Email Address."]);

        RuleFor(p => p.Password).Cascade(CascadeMode.Stop)
            .NotEmpty();
    }
}