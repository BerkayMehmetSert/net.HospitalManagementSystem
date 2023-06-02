using Domain.Common;

namespace Domain.Entities;

public class HospitalDiagnosisList : BaseEntity
{
    public Guid DepartmentId { get; set; }
    public string LabaratoryName { get; set; } 
    public string LabaratoryAddress { get; set; }
    public string LabaratoryPhone { get; set; }
    public string LabaratoryEmail { get; set; }
    public string Notes { get; set; }
    public Department Department { get; set; }
    public List<PatientDiagnosis> PatientDiagnoses { get; set; }
}