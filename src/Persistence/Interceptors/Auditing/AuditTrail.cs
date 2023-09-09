using Luna.Core.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Luna.Persistence.Interceptors.Auditing;

public class AuditTrail
{
    private readonly ISerializeService _serialize;

    public AuditTrail(EntityEntry entry, ISerializeService serialize)
    {
        Entry = entry;
        _serialize = serialize;
    }

    public EntityEntry Entry { get; }
    public Guid UserId { get; set; }
    public string? TableName { get; set; }
    public Dictionary<string, object?> KeyValues { get; } = new();
    public Dictionary<string, object?> OldValues { get; } = new();
    public Dictionary<string, object?> NewValues { get; } = new();
    public List<PropertyEntry> TemporaryProperties { get; } = new();
    public TrailType TrailType { get; set; }
    public List<string> ChangedColumns { get; } = new();
    public bool HasTemporaryProperties => TemporaryProperties.Count > 0;

    public Trail ToAuditTrail() =>
        new()
        {
            UserId = UserId,
            Type = TrailType.ToString(),
            TableName = TableName,
            DateTime = DateTime.UtcNow,
            PrimaryKey = _serialize.Serialize(KeyValues),
            OldValues = OldValues.Count == 0 ? null : _serialize.Serialize(OldValues),
            NewValues = NewValues.Count == 0 ? null : _serialize.Serialize(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : _serialize.Serialize(ChangedColumns)
        };
}