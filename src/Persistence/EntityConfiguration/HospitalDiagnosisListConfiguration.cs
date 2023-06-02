using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class HospitalDiagnosisListConfiguration : IEntityTypeConfiguration<HospitalDiagnosisList>
{
    public void Configure(EntityTypeBuilder<HospitalDiagnosisList> builder)
    {
        builder.ToTable("HospitalDiagnosisLists").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.LabaratoryName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LabaratoryAddress).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LabaratoryPhone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.LabaratoryEmail).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Notes).IsRequired(false).HasMaxLength(100);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.HospitalDiagnosisLists)
            .HasForeignKey(x => x.DepartmentId);

        builder.HasIndex(x => x.LabaratoryName).IsUnique();
    }
}