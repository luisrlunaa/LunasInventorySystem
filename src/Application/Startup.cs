using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Luna.Core.Application;
public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(opts => opts.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            .AddValidatorsFromAssembly(AssemblyReference.Assembly);
    }
}