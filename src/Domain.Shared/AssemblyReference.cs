using System.Reflection;

namespace Luna.Core.Domain.Extended;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string? RootNameSpace = typeof(AssemblyReference).Namespace;
}
