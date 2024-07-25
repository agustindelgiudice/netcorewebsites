using Microsoft.Extensions.Configuration;

namespace NetCoreWebsitesBL.Common
{
    public static class AppSettings
    {
        public static AppSettingsModel Settings { get; private set; } = new AppSettingsModel();

        public static void Initialize(AppSettingsModel settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public static void Initialize(IConfiguration configuration)
        {
            Settings = configuration.GetSection("AppSettings").Get<AppSettingsModel>() ?? new AppSettingsModel();
        }
    }
}
