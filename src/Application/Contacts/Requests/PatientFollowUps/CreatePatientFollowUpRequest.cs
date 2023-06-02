namespace Application.Contacts.Requests.PatientFollowUps;

public class CreatePatientFollowUpRequest : BaseRequest
{
    public Guid PatientHistoryId { get; set; }
    public string Notes { get; set; }
}