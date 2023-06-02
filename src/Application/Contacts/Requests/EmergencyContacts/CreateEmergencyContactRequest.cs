namespace Application.Contacts.Requests.EmergencyContacts;

public class CreateEmergencyContactRequest : BaseRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Relationship { get; set; }
    public string Email { get; set; }
}