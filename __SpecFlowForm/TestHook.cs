using System.Configuration;
using BoDi;
using Contaract;
using AppiumConfiguration;
using TechTalk.SpecFlow;

namespace SpecFlowForm;

[Binding]
public class TestHook
{
    private readonly IObjectContainer objectContainer;

    public TestHook(IObjectContainer objectContainer)
    {
        this.objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void Initialize()
    {
        var configurationManager = new ConfigurationManager();

        objectContainer.RegisterInstanceAs<IConfigurationManager>(configurationManager);

        var appiumGuiTestManager = new AppiumGuiTestManager(configurationManager);

        objectContainer.RegisterInstanceAs<IAppiumGuiTestManager>(appiumGuiTestManager);

        objectContainer.RegisterInstanceAs(appiumGuiTestManager.MainForm);
        objectContainer.RegisterInstanceAs(appiumGuiTestManager.Calculator); 
    }

}