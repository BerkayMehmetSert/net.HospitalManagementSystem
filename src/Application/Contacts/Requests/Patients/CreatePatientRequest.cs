using Application.Contacts.Requests.HealthInsurances;

namespace Application.Contacts.Requests.Patients;

public class CreatePatientRequest : BaseRequest
{
    public Guid EmergencyContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public ICollection<CreateHealthInsuranceRequest> HealthInsurances { get; set; }
}