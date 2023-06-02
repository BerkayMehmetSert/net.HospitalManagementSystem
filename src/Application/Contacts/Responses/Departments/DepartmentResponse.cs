using Application.Contacts.Responses.Doctors;
using Application.Contacts.Responses.HospitalDiagnosisLists;

namespace Application.Contacts.Responses.Departments;

public class DepartmentResponse : BaseResponse
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Notes { get; set; }
    public List<HospitalDiagnosisListResponse> HospitalDiagnosisLists { get; set; }
    public List<DoctorResponse> Doctors { get; set; }
}