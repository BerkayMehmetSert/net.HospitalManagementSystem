using Domain.Common;

namespace Domain.Entities;

public class PatientAdmission : BaseEntity
{
    public Guid PatientHistoryId { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public DateTime DateOfDischarge { get; set; }
    public string WardNumber { get; set; }
    public string BedNumber { get; set; }
    public string Notes { get; set; }
    public PatientHistory PatientHistory { get; set; }
}