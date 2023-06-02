using Domain.Entities;

namespace Application.Contacts.Repositories;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
    IBaseRepository<Department> DepartmentRepository { get; }
    IBaseRepository<Doctor> DoctorRepository { get; }
    IBaseRepository<EmergencyContact> EmergencyContactRepository { get; }
    IBaseRepository<HealthInsurance> HealthInsuranceRepository { get; }
    IBaseRepository<HospitalDiagnosisList> HospitalDiagnosisListRepository { get; }
    IBaseRepository<Patient> PatientRepository { get; }
    IBaseRepository<PatientAdmission> PatientAdmissionRepository { get; }
    IBaseRepository<PatientDiagnosis> PatientDiagnosisRepository { get; }
    IBaseRepository<PatientFollowUp> PatientFollowUpRepository { get; }
    IBaseRepository<PatientHistory> PatientHistoryRepository { get; }
    IBaseRepository<User> UserRepository { get; }
}