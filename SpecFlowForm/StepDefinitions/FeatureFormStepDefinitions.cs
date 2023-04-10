using Contaract;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowForm.StepDefinitions
{
    [Binding]
    public class FeatureFormStepDefinitions
    {
        private readonly IGuiTestManager tester;


        [Given(@"an empty Form")]
        public void GivenAnEmptyForm()
        {
            tester.MainForm.Start();
        }

        [When(@"click on a button")]
        public void WhenClickOnAButton()
        {
            throw new PendingStepException();
        }

        [Then(@"appear and disapear label")]
        public void ThenAppearAndDisapearLable()
        {
            throw new PendingStepException();
        }
    }
}
