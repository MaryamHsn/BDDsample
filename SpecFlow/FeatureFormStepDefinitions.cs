using System;
using Contracts;
using Flows;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public class FeatureFormStepDefinitions
    {
        private readonly User user;


        public FeatureFormStepDefinitions(IAppiumGuiTestManager appiumGuiTestManager)
        {
            user = new User(appiumGuiTestManager);

        }
        //public FeatureFormStepDefinitions(IGuiTestManager guiTestManager, IConfigurationManager configurationManager)
        //{
        //    _configurationManager = configurationManager;
        //    _guiTestManager = guiTestManager;
        //}
        [Given(@"an empty Form")]
        public void GivenAnEmptyForm()
        {
            user.RunApp();
        }

        [When(@"click on a button")]
        public void WhenClickOnAButton()
        {
            user.ClickOnSayHelloButton();
        }

        [Then(@"appear and disapear label")]
        public void ThenAppearAndDisapearLable()
        {
            // :)
        }
    }
}
