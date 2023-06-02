using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Application.Contacts.Repositories;
using Application.Contacts.Requests.Tokens;
using Application.Contacts.Responses.Tokens;
using Application.Contacts.Services;
using Domain.Entities;
using Infrastructure.Exceptions.Types;
using Infrastructure.Utilities.Security;
using Infrastructure.Utilities.Date;
using Microsoft.Extensions.Options;
using static Application.Contacts.Messages.Auth.BusinessMessages;

namespace Application.Services;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtConfig _jwtConfig;

    public TokenService(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
    {
        _unitOfWork = unitOfWork;
        _jwtConfig = jwtConfig.CurrentValue;
    }

    public TokenResponse GenerateToken(CreateTokenRequest request)
    {
        var user = _unitOfWork.UserRepository.Get(x => x.Email.Equals(request.Email));

        if (user is null) throw new NotFoundException(UserNotFound);
        
        CheckIfUserPasswordIsCorrect(user, request.Password);

        if (user.Role is null) throw new AuthenticationException(UserRoleNotFound);

        var token = GenerateJwtToken(user, CalculateDate.GetCurrentDateTime());

        return new TokenResponse
        {
            AccessToken = token,
            ExpireTime = CalculateDate.GetCurrentDateTime().AddMinutes(_jwtConfig.AccessTokenExpiration),
            Role = user.Role
        };
    }

    private string GenerateJwtToken(User user, DateTime dateTime)
    {
        var claims = GetClaim(user);

        var secret = SecurityKeyHelper.CreateSecurityKey(_jwtConfig.Secret);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(secret);

        var jwtToken = new JwtSecurityToken(
            _jwtConfig.Issuer,
            _jwtConfig.Audience,
            claims,
            expires: dateTime.AddMinutes(_jwtConfig.AccessTokenExpiration),
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    private static IEnumerable<Claim> GetClaim(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName}"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            new Claim("Role", user.Role),
            new Claim("Email", user.Email),
            new Claim("UserId", user.Id.ToString())
        };

        return claims;
    }
    private static void CheckIfUserPasswordIsCorrect(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(UserPasswordIncorrect);
    }
}