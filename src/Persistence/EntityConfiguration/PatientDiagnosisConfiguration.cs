using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientDiagnosisConfiguration : IEntityTypeConfiguration<PatientDiagnosis>
{
    public void Configure(EntityTypeBuilder<PatientDiagnosis> builder)
    {
        builder.ToTable("PatientDiagnoses").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DateOfDiagnosis).IsRequired();
        builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(100);

        builder.HasOne(x => x.PatientHistory)
            .WithMany(x => x.PatientDiagnoses)
            .HasForeignKey(x => x.PatientHistoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.HospitalDiagnosisList)
            .WithMany(x => x.PatientDiagnoses)
            .HasForeignKey(x => x.HospitalDiagnosisListId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.PatientDiagnoses)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}