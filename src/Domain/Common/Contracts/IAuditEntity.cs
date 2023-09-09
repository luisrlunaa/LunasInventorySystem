namespace Luna.Core.Domain.Common.Contracts;

public interface IAuditEntity
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; }
    public Guid LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}