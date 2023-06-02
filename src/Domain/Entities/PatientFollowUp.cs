using Domain.Common;

namespace Domain.Entities;

public class PatientFollowUp : BaseEntity
{
    public Guid PatientHistoryId { get; set; }
    public DateTime DateOfFollowUp { get; set; }
    public string Notes { get; set; }
    public PatientHistory PatientHistory { get; set; }
}