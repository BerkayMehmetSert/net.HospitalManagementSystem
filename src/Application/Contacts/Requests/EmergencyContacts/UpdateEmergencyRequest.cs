namespace Application.Contacts.Requests.EmergencyContacts;

public class UpdateEmergencyRequest : BaseRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}