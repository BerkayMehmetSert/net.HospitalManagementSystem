namespace Application.Contacts.Responses.PatientAdmissions;

public class PatientAdmissionResponse : BaseResponse
{
    public Guid PatientHistoryId { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public DateTime DateOfDischarge { get; set; }
    public string WardNumber { get; set; }
    public string BedNumber { get; set; }
    public string Notes { get; set; }
}