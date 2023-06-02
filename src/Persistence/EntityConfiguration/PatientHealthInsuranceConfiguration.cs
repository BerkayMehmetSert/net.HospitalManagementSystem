using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientHealthInsuranceConfiguration : IEntityTypeConfiguration<PatientHealthInsurance>
{
    public void Configure(EntityTypeBuilder<PatientHealthInsurance> builder)
    {
        builder.ToTable("PatientHealthInsurances").HasKey(x => new { x.PatientId, x.HealthInsuranceId });

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.PatientHealthInsurances)
            .HasForeignKey(x => x.PatientId);

        builder.HasOne(x => x.HealthInsurance)
            .WithMany(x => x.PatientHealthInsurances)
            .HasForeignKey(x => x.HealthInsuranceId);
    }
}