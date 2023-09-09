using Microsoft.AspNetCore.Identity;

namespace Luna.Persistence.Identity;
public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public Guid? EmployeeId { get; set; }
}