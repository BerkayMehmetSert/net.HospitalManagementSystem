using Domain.Common;

namespace Domain.Entities;

public class Patient : BaseEntity
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
    public EmergencyContact EmergencyContact { get; set; }
    public ICollection<PatientHealthInsurance> PatientHealthInsurances { get; set; }
    public List<PatientHistory> PatientHistories { get; set; }

    public Patient()
    {
        PatientHealthInsurances = new List<PatientHealthInsurance>();
    }
}