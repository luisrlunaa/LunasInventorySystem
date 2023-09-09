using System.ComponentModel.DataAnnotations;

namespace Luna.Persistence
{
    public class DatabaseSettings : IValidatableObject
    {
        public string Provider { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Provider))
            {
                yield return new ValidationResult(
                    $"{nameof(DatabaseSettings)}.{nameof(Provider)} is not configured",
                    new[] { nameof(Provider) });
            }

            if (string.IsNullOrEmpty(ConnectionString))
            {
                yield return new ValidationResult(
                    $"{nameof(DatabaseSettings)}.{nameof(ConnectionString)} is not configured",
                    new[] { nameof(ConnectionString) });
            }
        }
    }
}
