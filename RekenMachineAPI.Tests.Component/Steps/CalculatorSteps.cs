using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RekenMachineAPI.Tests.Component.Helpers;
using TechTalk.SpecFlow;

namespace RekenMachineAPI.Tests.Component.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly SystemUnderTest _sut;

        public CalculatorSteps(SystemUnderTest sut)
        {
            _sut = sut;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _sut.Database.SaveChanges();
//            ScenarioContext.Current.Pending();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
//            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
//            ScenarioContext.Current.Pending();
        }

    }
}
