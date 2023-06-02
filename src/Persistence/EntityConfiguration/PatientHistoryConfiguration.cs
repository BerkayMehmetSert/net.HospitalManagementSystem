using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientHistoryConfiguration : IEntityTypeConfiguration<PatientHistory>
{
    public void Configure(EntityTypeBuilder<PatientHistory> builder)
    {
        builder.ToTable("PatientHistories").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DateOfVisit).IsRequired();
        builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(100);

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.PatientHistories)
            .HasForeignKey(x => x.PatientId);

        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.PatientHistories)
            .HasForeignKey(x => x.DoctorId);
    }
}