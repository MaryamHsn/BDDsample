namespace Contracts
{
    public interface IConfigurationManager
    {
        string TestProjectDirectory { get; }
        string WindowsApplicationDriverUrl { get; }
        string ApplicationExecutablePath { get; }
        string ApplicationExecutableFileName { get; }
        string AutomatedTestProjectName { get; }
    }
}