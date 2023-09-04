using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Luna.Infrastructure.Localization;

internal static class Startup
{
    internal static IServiceCollection AddLocalization(this IServiceCollection services, IConfiguration config)
    {
        var localizationSettings = config.GetSection(nameof(LocalizationSettings)).Get<LocalizationSettings>();

        if (localizationSettings?.EnableLocalization is true
            && localizationSettings.ResourcesPath is not null)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                if (localizationSettings.SupportedCultures != null)
                {
                    var supportedCultures = localizationSettings.SupportedCultures.Select(x => new CultureInfo(x)).ToList();

                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                }

                options.DefaultRequestCulture = new RequestCulture(localizationSettings.DefaultRequestCulture ?? "en-US");
                options.FallBackToParentCultures = localizationSettings.FallBackToParent ?? true;
                options.FallBackToParentUICultures = localizationSettings.FallBackToParent ?? true;
            });

        }

        return services;
    }
}