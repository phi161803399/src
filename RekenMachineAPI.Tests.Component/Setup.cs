using System.Web.Http;
using Autofac;
using Microsoft.Owin.Testing;
using RekenMachineAPI.API;
using RekenMachineAPI.Tests.Component.Helpers;
using TechTalk.SpecFlow;

namespace RekenMachineAPI.Tests.Component
{
    [Binding]
    public class Setup
    {
        private readonly SystemUnderTest _systemUnderTest;

        public Setup(SystemUnderTest systemUnderTest)
        {
            _systemUnderTest = systemUnderTest;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DatabaseManager.Drop();
            DatabaseManager.Create();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DatabaseManager.Drop();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var httpConfig = new HttpConfiguration();
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApiModule(httpConfig));
            builder.RegisterModule(new TestModule());

            _systemUnderTest.Container = builder.Build();

            _systemUnderTest.Server = TestServer.Create(app =>
            {
                Startup.ConfigureOwin(httpConfig, _systemUnderTest.Container);
                Startup.ConfigureAppBuilder(app, httpConfig, _systemUnderTest.Container);
            });
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DatabaseManager.Truncate();
            _systemUnderTest.Dispose();
        }
    }
}