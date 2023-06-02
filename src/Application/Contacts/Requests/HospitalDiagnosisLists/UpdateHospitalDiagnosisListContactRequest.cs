namespace Application.Contacts.Requests.HospitalDiagnosisLists;

public class UpdateHospitalDiagnosisListContactRequest : BaseRequest
{
    public string LabaratoryName { get; set; }
    public string LabaratoryAddress { get; set; }
    public string LabaratoryPhone { get; set; }
    public string LabaratoryEmail { get; set; }
}