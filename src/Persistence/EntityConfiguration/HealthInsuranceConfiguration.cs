using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class HealthInsuranceConfiguration : IEntityTypeConfiguration<HealthInsurance>
{
    public void Configure(EntityTypeBuilder<HealthInsurance> builder)
    {
        builder.ToTable("HealthInsurances").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.AddressLine1).IsRequired().HasMaxLength(100);
        builder.Property(x => x.AddressLine2).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.City).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Postcode).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.PatientHealthInsurances)
            .WithOne(x => x.HealthInsurance)
            .HasForeignKey(x => x.HealthInsuranceId);

        builder.HasIndex(x => x.CompanyName).IsUnique();
    }
}