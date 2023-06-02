namespace Application.Contacts.Responses.Tokens;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpireTime { get; set; }
    public string Role { get; set; }
}