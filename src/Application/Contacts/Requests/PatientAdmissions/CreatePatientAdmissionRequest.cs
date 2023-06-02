namespace Application.Contacts.Requests.PatientAdmissions;

public class CreatePatientAdmissionRequest : BaseRequest
{
    public Guid PatientHistoryId { get; set; }
    public string WardNumber { get; set; }
    public string BedNumber { get; set; }
    public string Notes { get; set; }
}