namespace Application.Contacts.Requests.PatientDiagnoses;

public class CreatePatientDiagnosisRequest : BaseRequest
{
    public Guid PatientHistoryId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid HospitalDiagnosisListId { get; set; }
    public string Notes { get; set; }
}