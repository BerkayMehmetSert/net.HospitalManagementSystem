using Application.Contacts.Responses.Patients;

namespace Application.Contacts.Responses.EmergencyContacts;

public class EmergencyContactResponse : BaseResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Relationship { get; set; }
    public string Email { get; set; }
    public List<PatientResponse> Patients { get; set; }
}