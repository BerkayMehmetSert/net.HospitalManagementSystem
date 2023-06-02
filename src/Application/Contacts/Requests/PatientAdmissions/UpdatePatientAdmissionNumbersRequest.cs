namespace Application.Contacts.Requests.PatientAdmissions;

public class UpdatePatientAdmissionNumbersRequest : BaseRequest
{
    public string WardNumber { get; set; }
    public string BedNumber { get; set; }
}