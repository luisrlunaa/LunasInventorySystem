using Finbuckle.MultiTenant;
using Luna.Core.Domain.Common.Interfaces;
using Luna.Core.Domain.Company;
using Luna.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Luna.Persistence.Contexts;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializeService serializer, IOptions<DatabaseSettings> dbSettings)
        : base(currentTenant, options, currentUser, serializer, dbSettings)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Company);
    }
}