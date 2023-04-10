using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumConfiguration;
using BoDi;
using Contracts;
using TechTalk.SpecFlow;

namespace SpecFlow
{
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
}
