using Contaract;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowForm.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly IGuiTestManager guiTestManager;
        private readonly ICalculator _calculator;

        private int _result;

        public CalculatorStepDefinitions(ICalculator calculator)
        {
            _calculator = calculator;
        }
        //public CalculatorStepDefinitions(IGuiTestManager _guiTestManager)
        //{
        //    this.guiTestManager = _guiTestManager;
        //}
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            guiTestManager.Calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            guiTestManager.Calculator.SecondNumber = number;

        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = guiTestManager.Calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            guiTestManager.Calculator.Should().Be(result);
        }
    }
}