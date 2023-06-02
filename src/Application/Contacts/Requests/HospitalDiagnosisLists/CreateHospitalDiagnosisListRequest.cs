namespace Application.Contacts.Requests.HospitalDiagnosisLists;

public class CreateHospitalDiagnosisListRequest : BaseRequest
{
    public Guid DepartmentId { get; set; }
    public string LabaratoryName { get; set; }
    public string LabaratoryAddress { get; set; }
    public string LabaratoryPhone { get; set; }
    public string LabaratoryEmail { get; set; }
    public string Notes { get; set; }
}