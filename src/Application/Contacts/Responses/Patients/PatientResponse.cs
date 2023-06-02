using Application.Contacts.Responses.HealthInsurances;
using Application.Contacts.Responses.PatientHistories;

namespace Application.Contacts.Responses.Patients;

public class PatientResponse : BaseResponse
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
    public ICollection<HealthInsuranceResponse> HealthInsurances { get; set; }
    public List<PatientHistoryResponse> PatientHistories { get; set; }
}