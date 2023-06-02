using Domain.Common;

namespace Domain.Entities;

public class Doctor : BaseEntity
{
    public Guid DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Department Department { get; set; }
    public List<PatientDiagnosis> PatientDiagnoses { get; set; }
    public List<PatientHistory> PatientHistories { get; set; }
}