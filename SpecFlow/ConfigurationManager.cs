using AppConfig = System.Configuration.ConfigurationManager;
using Contracts;

namespace SpecFlow
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string TestProjectDirectory => $@"{AppConfig.AppSettings["TestProjectDirectory"]}";
        public string WindowsApplicationDriverUrl => AppConfig.AppSettings["WindowsApplicationDriverUrl"];
        public string ApplicationExecutablePath => AppConfig.AppSettings["ApplicationExecutablePath"];
        public string ApplicationExecutableFileName => AppConfig.AppSettings["ApplicationExecutableFileName"];
        public string AutomatedTestProjectName => AppConfig.AppSettings["AutomatedTestProjectName"];
    }
}
