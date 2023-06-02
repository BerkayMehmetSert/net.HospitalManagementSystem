namespace Application.Contacts.Requests.EmergencyContacts;

public class UpdateEmergencyContactRequest : BaseRequest
{
    public string Phone { get; set; }
    public string Email { get; set; }
}