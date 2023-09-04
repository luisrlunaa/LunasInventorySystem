using System.Collections.ObjectModel;

namespace Luna.Infrastructure.Localization
{
    public class LocalizationSettings
    {

        public bool? EnableLocalization { get; set; }
        public string? ResourcesPath { get; set; }
        public ReadOnlyCollection<string>? SupportedCultures { get; set; }
        public string? DefaultRequestCulture { get; set; }
        public bool? FallBackToParent { get; set; }
    }
}