using Luna.Infrastructure.Localization;
using Luna.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luna.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddServices()
                .AddLocalization()
                .AddHttpContextAccessor();
        }
    }
}
