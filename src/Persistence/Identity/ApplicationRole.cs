using Microsoft.AspNetCore.Identity;

namespace Luna.Persistence.Identity;
public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }

    public ApplicationRole(string name, string? description = default)
        : base(name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        Description = description;
        NormalizedName = name.ToUpperInvariant();
    }
}