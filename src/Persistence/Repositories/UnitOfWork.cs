using Application.Contacts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    private readonly IHttpContextAccessor _contextAccessor;
    public UnitOfWork(BaseDbContext context, IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _contextAccessor = contextAccessor;
        DepartmentRepository = new BaseRepository<Department>(context, contextAccessor);
        DoctorRepository = new BaseRepository<Doctor>(context, contextAccessor);
        EmergencyContactRepository = new BaseRepository<EmergencyContact>(context, contextAccessor);
        HealthInsuranceRepository = new BaseRepository<HealthInsurance>(context, contextAccessor);
        HospitalDiagnosisListRepository = new BaseRepository<HospitalDiagnosisList>(context, contextAccessor);
        PatientRepository = new BaseRepository<Patient>(context, contextAccessor);
        PatientAdmissionRepository = new BaseRepository<PatientAdmission>(context, contextAccessor);
        PatientDiagnosisRepository = new BaseRepository<PatientDiagnosis>(context, contextAccessor);
        PatientFollowUpRepository = new BaseRepository<PatientFollowUp>(context, contextAccessor);
        PatientHistoryRepository = new BaseRepository<PatientHistory>(context, contextAccessor);
        UserRepository = new BaseRepository<User>(context, contextAccessor);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IBaseRepository<Department> DepartmentRepository { get; }
    public IBaseRepository<Doctor> DoctorRepository { get; }
    public IBaseRepository<EmergencyContact> EmergencyContactRepository { get; }
    public IBaseRepository<HealthInsurance> HealthInsuranceRepository { get; }
    public IBaseRepository<HospitalDiagnosisList> HospitalDiagnosisListRepository { get; }
    public IBaseRepository<Patient> PatientRepository { get; }
    public IBaseRepository<PatientAdmission> PatientAdmissionRepository { get; }
    public IBaseRepository<PatientDiagnosis> PatientDiagnosisRepository { get; }
    public IBaseRepository<PatientFollowUp> PatientFollowUpRepository { get; }
    public IBaseRepository<PatientHistory> PatientHistoryRepository { get; }
    public IBaseRepository<User> UserRepository { get; }
}