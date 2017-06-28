using System.Configuration;

namespace Windows.Service.Bootstrapper
{
    public class ServiceConfig
    {
        public static string ServiceName { get; } = InitializeFromAppConfig("Service.Name");
        public static string ServiceDescription { get; } = InitializeFromAppConfig("Service.Description");

        private static string InitializeFromAppConfig(string key)
        {
            if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[key]))
                throw new ConfigurationErrorsException($"No '{key}' provided in AppConfig");
            return ConfigurationManager.AppSettings[key];
        }
    }
}
