namespace Domain.Entities;

public class PatientHealthInsurance
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid HealthInsuranceId { get; set; }
    public HealthInsurance HealthInsurance { get; set; }
}