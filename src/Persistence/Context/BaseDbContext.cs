using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<EmergencyContact> EmergencyContacts { get; set; }
    public DbSet<HealthInsurance> HealthInsurances { get; set; }
    public DbSet<HospitalDiagnosisList> HospitalDiagnosisLists { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientAdmission> PatientAdmissions { get; set; }
    public DbSet<PatientDiagnosis> PatientDiagnoses { get; set; }
    public DbSet<PatientFollowUp> PatientFollowUps { get; set; }
    public DbSet<PatientHealthInsurance> PatientHealthInsurances { get; set; }
    public DbSet<PatientHistory> PatientHistories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}