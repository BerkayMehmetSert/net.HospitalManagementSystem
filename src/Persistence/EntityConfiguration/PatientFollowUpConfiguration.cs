using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientFollowUpConfiguration : IEntityTypeConfiguration<PatientFollowUp>
{
    public void Configure(EntityTypeBuilder<PatientFollowUp> builder)
    {
        builder.ToTable("PatientFollowUps").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DateOfFollowUp).IsRequired();
        builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(100);

        builder.HasOne(x => x.PatientHistory)
            .WithMany(x => x.PatientFollowUps)
            .HasForeignKey(x => x.PatientHistoryId);
    }
}