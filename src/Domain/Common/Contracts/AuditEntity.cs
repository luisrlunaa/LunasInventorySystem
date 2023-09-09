namespace Luna.Core.Domain.Common.Contracts;

public abstract class AuditEntity : AuditEntity<Guid>
{
}

public abstract class AuditEntity<T> : BaseEntity<T>, IAuditEntity, ISoftDelete
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; private set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }

    protected AuditEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}