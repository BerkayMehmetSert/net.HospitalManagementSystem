namespace Application.Contacts.Requests.Tokens;

public class CreateTokenRequest : BaseRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}