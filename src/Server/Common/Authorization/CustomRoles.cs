using System.Collections.ObjectModel;

namespace Luna.Server.Common.Authorization;

public static class CustomRoles
{
    public const string Admin = "Admin";
    public const string Basic = "Basic";

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Admin,
        Basic
    });

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}