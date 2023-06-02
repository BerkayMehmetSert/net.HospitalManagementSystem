namespace Application.Contacts.Requests.Patients;

public class UpdatePatientEmergencyContactRequest : BaseRequest
{
    public Guid EmergencyContactId { get; set; }
}