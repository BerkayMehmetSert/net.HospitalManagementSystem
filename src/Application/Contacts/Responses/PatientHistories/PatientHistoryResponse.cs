using Application.Contacts.Responses.PatientAdmissions;
using Application.Contacts.Responses.PatientDiagnoses;
using Application.Contacts.Responses.PatientFollowUps;

namespace Application.Contacts.Responses.PatientHistories;

public class PatientHistoryResponse : BaseResponse
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Notes { get; set; }
    public List<PatientFollowUpResponse> PatientFollowUps { get; set; }
    public List<PatientDiagnosisResponse> PatientDiagnoses { get; set; }
    public List<PatientAdmissionResponse> PatientAdmissions { get; set; }
}