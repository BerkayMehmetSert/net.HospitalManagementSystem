namespace Application.Contacts.Requests.PatientHistories;

public class CreatePatientHistoryRequest : BaseRequest
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string Notes { get; set; }
}