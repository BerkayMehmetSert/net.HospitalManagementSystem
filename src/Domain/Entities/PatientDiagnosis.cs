using Domain.Common;

namespace Domain.Entities;

public class PatientDiagnosis : BaseEntity
{
    public Guid PatientHistoryId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid HospitalDiagnosisListId { get; set; }
    public DateTime DateOfDiagnosis { get; set; }
    public string Notes { get; set; }
    public PatientHistory PatientHistory { get; set; }
    public Doctor Doctor { get; set; }
    public HospitalDiagnosisList HospitalDiagnosisList { get; set; }
}