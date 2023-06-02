using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientAdmissionConfiguration : IEntityTypeConfiguration<PatientAdmission>
{
    public void Configure(EntityTypeBuilder<PatientAdmission> builder)
    {
        builder.ToTable("PatientAdmissions").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DateOfAdmission).IsRequired();
        builder.Property(x => x.DateOfDischarge).IsRequired();
        builder.Property(x => x.WardNumber).IsRequired().HasMaxLength(10);
        builder.Property(x => x.BedNumber).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(100);

        builder.HasOne(x => x.PatientHistory)
            .WithMany(x => x.PatientAdmissions)
            .HasForeignKey(x => x.PatientHistoryId);
    }
}