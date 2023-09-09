using Finbuckle.MultiTenant.EntityFrameworkCore;
using Luna.Core.Domain.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luna.Persistence.Configurations;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.IsMultiTenant();

        builder.HasKey(b => b.EmployeeId);

        builder.Property(b => b.FirstName)
            .HasMaxLength(30)
            .IsUnicode(false);

        builder.Property(b => b.LastName)
            .HasMaxLength(30)
            .IsUnicode(false);

        builder.Property(b => b.ApplicationUserId);
    }
}