using FluentAssertions;
using NetArchTest.Rules;
using Application = Luna.Core.Application.AssemblyReference;
using ClientRef = Luna.Infrastructure.AssemblyReference;
using Contracts = Luna.Server.Contracts.AssemblyReference;
using Domain = Luna.Core.Domain.AssemblyReference;
using DomainExtended = Luna.Core.Domain.Common.AssemblyReference;
using InfrastructureRef = Luna.Infrastructure.AssemblyReference;
using PersistenceRef = Luna.Persistence.AssemblyReference;
using ServerRef = Luna.Infrastructure.AssemblyReference;

namespace Luna.Architecture.Tests;

public class ArchitectureTests
{
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = Domain.Assembly;

        var otherProjects = new[]
        {
                Contracts.RootNameSpace,
                Application.RootNameSpace,
                DomainExtended.RootNameSpace,
                InfrastructureRef.RootNameSpace,
                PersistenceRef.RootNameSpace,
                ClientRef.RootNameSpace,
                ServerRef.RootNameSpace,
            };

        // Act

        var testResult = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        var causes = string.Join(",", testResult.FailingTypeNames ?? Enumerable.Empty<string>());
        testResult.IsSuccessful.Should().BeTrue("Specific dependencies {0}", causes);
    }
}
