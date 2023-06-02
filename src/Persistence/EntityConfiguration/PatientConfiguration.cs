using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.Property(x => x.AddressLine1).IsRequired().HasMaxLength(100);
        builder.Property(x => x.AddressLine2).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.City).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Postcode).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.EmergencyContact)
            .WithMany(x => x.Patients)
            .HasForeignKey(x => x.EmergencyContactId);

        builder.HasMany(x => x.PatientHealthInsurances)
            .WithOne(x => x.Patient)
            .HasForeignKey(x => x.PatientId);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}