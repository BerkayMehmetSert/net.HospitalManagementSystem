using Application.Contacts.Requests.Tokens;
using Application.Contacts.Responses.Tokens;

namespace Application.Contacts.Services;

public interface ITokenService
{
    TokenResponse GenerateToken(CreateTokenRequest request);
}