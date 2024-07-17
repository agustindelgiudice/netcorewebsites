namespace NetCoreWebsitesBL.Configurations
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }

        // Constructor predeterminado
        public SmtpSettings()
        {
            Host = string.Empty;
            Port = 0;
            Username = string.Empty;
            Password = string.Empty;
            EnableSsl = false;
        }
    }
}
