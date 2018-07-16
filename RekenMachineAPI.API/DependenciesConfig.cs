using System.Web.Http;
using Autofac;

namespace RekenMachineAPI.API
{
    public static class DependenciesConfig
    {
        public static IContainer Configure(HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApiModule(httpConfig));
            return builder.Build();
        }
    }
}