namespace Application.Contacts.Responses.PatientFollowUps;

public class PatientFollowUpResponse : BaseResponse
{
    public Guid PatientHistoryId { get; set; }
    public DateTime DateOfFollowUp { get; set; }
    public string Notes { get; set; }
}