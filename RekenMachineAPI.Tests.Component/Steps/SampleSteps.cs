//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Threading.Tasks;
//using RekenMachineAPI.Domain;
//using RekenMachineAPI.Tests.Component.Helpers;
//using TechTalk.SpecFlow;
//using TechTalk.SpecFlow.Assist;
//using Xunit;

//namespace RekenMachineAPI.Tests.Component.Steps
//{
//    [Binding]
//    public class SampleSteps
//    {
//        private readonly SystemUnderTest _sut;

//        public SampleSteps(SystemUnderTest sut)
//        {
//            _sut = sut;
//        }

//        [Given(@"I seed the following samples")]
//        public async Task GivenISeedTheFollowingSamples(Table table)
//        {
//            _sut.Database.Set<Sample>().AddRange(table.CreateSet<Sample>());
//            await _sut.Database.SaveChangesAsync();
//        }

//        [When(@"I get all samples")]
//        public async Task WhenIGetAllSamples()
//        {
//            var response = await _sut.Server.GetAsJson<IEnumerable<Sample>>("api/samples");
//            ScenarioContext.Current.Add("response", response);
//        }

//        [Then(@"I retrieve the following samples")]
//        public void ThenIRetrieveTheFollowingSamples(Table table)
//        {
//            var expected = table.CreateSet<Sample>();
//            var response = (TestServerResponseWithData<IEnumerable<Sample>>) ScenarioContext.Current["response"];
//            Assert.Equal(expected, response.Data, new DeepObjectComparer());
//        }

//        [When(@"I get sample by id (.*)")]
//        public async Task WhenIGetSampleById(int id)
//        {
//            var response = await _sut.Server.GetAsJson<Sample>($"api/samples/{id}");
//            ScenarioContext.Current.Add("response", response);
//        }

//        [Then(@"I retrieve the following sample")]
//        public void ThenIRetrieveTheFollowingSample(Table table)
//        {
//            var expected = table.CreateInstance<Sample>();
//            var response = (TestServerResponseWithData<Sample>) ScenarioContext.Current["response"];
//            Assert.Equal(expected, response.Data, new DeepObjectComparer());
//        }

//        [When(@"I post a sample")]
//        public async Task WhenIPostASample(Table table)
//        {
//            var sample = table.CreateInstance<Sample>();
//            var response = await _sut.Server.PostJson("api/samples", sample);
//            ScenarioContext.Current.Add("response", response);
//        }

//        [Then(@"I should have the following samples")]
//        public async Task ThenIShouldHaveTheFollowingSamples(Table table)
//        {
//            var expected = table.CreateSet<Sample>();
//            var actual = await _sut.Database.Set<Sample>().AsNoTracking().ToListAsync();
//            Assert.Equal(expected, actual, new DeepObjectComparer());
//        }

//        [When(@"I put sample with id (.*)")]
//        public async Task WhenIPutSampleWithId(int id, Table table)
//        {
//            var sample = table.CreateInstance<Sample>();
//            var response = await _sut.Server.PutJson($"api/samples/{id}", sample);
//            ScenarioContext.Current.Add("response", response);
//        }

//        [When(@"I delete sample with id (.*)")]
//        public async Task WhenIDeleteSampleWithId(int id)
//        {
//            var response = await _sut.Server.Delete($"api/samples/{id}");
//            ScenarioContext.Current.Add("response", response);
//        }

//        [Then(@"I retrieve (.*)")]
//        public void ThenIRetrieve(int statusCode)
//        {
//            var response = (TestServerResponse) ScenarioContext.Current["response"];
//            Assert.Equal((int) response.HttpResponseMessage.StatusCode, statusCode);
//        }
//    }
//}