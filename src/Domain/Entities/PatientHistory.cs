using Domain.Common;

namespace Domain.Entities;

public class PatientHistory : BaseEntity
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Notes { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public List<PatientFollowUp> PatientFollowUps { get; set; }
    public List<PatientDiagnosis> PatientDiagnoses { get; set; }
    public List<PatientAdmission> PatientAdmissions { get; set; }
}