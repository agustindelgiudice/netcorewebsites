using NetCoreWebsitesBL.Configurations;

namespace NetCoreWebsitesBL.Common
{
    public class AppSettingsModel
    {
        public string SomeSetting { get; set; } = string.Empty;
        public SmtpSettings SmtpSettings { get; set; } = new SmtpSettings();
        public EmailSettings EmailSettings { get; set; } = new EmailSettings();
    }
}
