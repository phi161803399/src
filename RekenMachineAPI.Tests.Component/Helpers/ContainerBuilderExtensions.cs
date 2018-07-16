using Autofac;
using Moq;

namespace RekenMachineAPI.Tests.Component.Helpers
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterMock<T>(this ContainerBuilder containerbuilder) where T : class
        {
            var mock = new Mock<T>();

            containerbuilder.RegisterInstance(mock.Object).As(typeof(T));
            containerbuilder.RegisterInstance(mock).As<Mock<T>>();
        }
    }
}