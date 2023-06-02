using Application.Contacts.Responses.PatientDiagnoses;

namespace Application.Contacts.Responses.HospitalDiagnosisLists;

public class HospitalDiagnosisListResponse : BaseResponse
{
    public Guid DepartmentId { get; set; }
    public string LabaratoryName { get; set; }
    public string LabaratoryAddress { get; set; }
    public string LabaratoryPhone { get; set; }
    public string LabaratoryEmail { get; set; }
    public string Notes { get; set; }
    public List<PatientDiagnosisResponse> PatientDiagnoses { get; set; }
}