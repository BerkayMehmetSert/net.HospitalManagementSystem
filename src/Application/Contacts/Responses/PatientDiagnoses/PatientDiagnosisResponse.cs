namespace Application.Contacts.Responses.PatientDiagnoses;

public class PatientDiagnosisResponse : BaseResponse
{
    public Guid PatientHistoryId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid HospitalDiagnosisListId { get; set; }
    public DateTime DateOfDiagnosis { get; set; }
    public string Notes { get; set; }
}