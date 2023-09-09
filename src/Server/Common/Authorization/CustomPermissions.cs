using System.Collections.ObjectModel;

namespace Luna.Server.Common.Authorization;

public static class CustomAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class CustomResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
}

public static class CustomPermissions
{
    private static readonly CustomPermission[] _all = new CustomPermission[]
    {
        new("View Dashboard", CustomAction.View, CustomResource.Dashboard),
        new("View Hangfire", CustomAction.View, CustomResource.Hangfire),
        new("View Users", CustomAction.View, CustomResource.Users),
        new("Search Users", CustomAction.Search, CustomResource.Users),
        new("Create Users", CustomAction.Create, CustomResource.Users),
        new("Update Users", CustomAction.Update, CustomResource.Users),
        new("Delete Users", CustomAction.Delete, CustomResource.Users),
        new("Export Users", CustomAction.Export, CustomResource.Users),
        new("View UserRoles", CustomAction.View, CustomResource.UserRoles),
        new("Update UserRoles", CustomAction.Update, CustomResource.UserRoles),
        new("View Roles", CustomAction.View, CustomResource.Roles),
        new("Create Roles", CustomAction.Create, CustomResource.Roles),
        new("Update Roles", CustomAction.Update, CustomResource.Roles),
        new("Delete Roles", CustomAction.Delete, CustomResource.Roles),
        new("View RoleClaims", CustomAction.View, CustomResource.RoleClaims),
        new("Update RoleClaims", CustomAction.Update, CustomResource.RoleClaims),
        new("View Products", CustomAction.View, CustomResource.Products, IsBasic: true),
        new("Search Products", CustomAction.Search, CustomResource.Products, IsBasic: true),
        new("Create Products", CustomAction.Create, CustomResource.Products),
        new("Update Products", CustomAction.Update, CustomResource.Products),
        new("Delete Products", CustomAction.Delete, CustomResource.Products),
        new("Export Products", CustomAction.Export, CustomResource.Products),
        new("View Tenants", CustomAction.View, CustomResource.Tenants, IsRoot: true),
        new("Create Tenants", CustomAction.Create, CustomResource.Tenants, IsRoot: true),
        new("Update Tenants", CustomAction.Update, CustomResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", CustomAction.UpgradeSubscription, CustomResource.Tenants, IsRoot: true)
    };

    public static IReadOnlyList<CustomPermission> All { get; } = new ReadOnlyCollection<CustomPermission>(_all);
    public static IReadOnlyList<CustomPermission> Root { get; } = new ReadOnlyCollection<CustomPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<CustomPermission> Admin { get; } = new ReadOnlyCollection<CustomPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<CustomPermission> Basic { get; } = new ReadOnlyCollection<CustomPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record CustomPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
