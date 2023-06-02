using Domain.Common;

namespace Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Notes { get; set; }
    public List<HospitalDiagnosisList> HospitalDiagnosisLists { get; set; }
    public List<Doctor> Doctors { get; set; }
}