namespace SicopataPedidos.Core.Settings
{
    public class AppSettings
    {
        public string? ApiUrl { get; set; }
        public string[]? ClientUrls { get; set; }
        public string? FileStoreFolder { get; set; }
        public string? TemplateEmailPath { get; set; }
        public string? SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string? SmtpUser { get; set; }
        public string? SmtpPass { get; set; }
        public string? EmailFrom { get; set; }
    }
}
