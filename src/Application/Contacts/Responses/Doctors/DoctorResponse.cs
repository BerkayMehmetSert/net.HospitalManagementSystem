using Application.Contacts.Responses.PatientDiagnoses;
using Application.Contacts.Responses.PatientHistories;

namespace Application.Contacts.Responses.Doctors;

public class DoctorResponse : BaseResponse
{
    public Guid DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<PatientDiagnosisResponse> PatientDiagnoses { get; set; }
    public List<PatientHistoryResponse> PatientHistories { get; set; }
}