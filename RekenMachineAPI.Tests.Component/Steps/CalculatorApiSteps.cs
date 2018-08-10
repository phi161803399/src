using System.Collections.Generic;
using System.Threading.Tasks;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Tests.Component.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace RekenMachineAPI.Tests.Component.Steps
{
    [Binding]
    public class CalculatorApiSteps
    {
        private readonly SystemUnderTest _sut;

        public CalculatorApiSteps(SystemUnderTest sut)
        {
            _sut = sut;
        }
        [Given(@"I seed the following calculations")]
        public async Task GivenISeedTheFollowingCalculations(Table table)
        {
            //            ScenarioContext.Current.Pending();
            _sut.Database.Set<Calculation>().AddRange(table.CreateSet<Calculation>());
            await _sut.Database.SaveChangesAsync();
        }

        [When(@"I get all calculations")]
        public async Task WhenIGetAllCalculations()
        {
            //            ScenarioContext.Current.Pending();
            var response = await _sut.Server.GetAsJson<IEnumerable<Calculation>>("api/calculators");
            ScenarioContext.Current.Add("response", response);
        }

        [Then(@"I retrieve the following calculations")]
        public void ThenIRetrieveTheFollowingCalculations(Table table)
        {
//            ScenarioContext.Current.Pending();
            var expected = table.CreateSet<Calculation>();
            var response = (TestServerResponseWithData<IEnumerable<Calculation>>)ScenarioContext.Current["response"];
            Assert.Equal(expected, response.Data, new DeepObjectComparer());
//            Assert.Equal(expected, response.Data);
        }
    }
}
