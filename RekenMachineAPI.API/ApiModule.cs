using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PCore.Logging;
using PCore.Metrics.WebAPI;
using RekenMachineAPI.DAL;
using RekenMachineAPI.Service;
using Module = Autofac.Module;

namespace RekenMachineAPI.API
{
    public class ApiModule : Module
    {
        private readonly HttpConfiguration _httpConfig;

        public ApiModule(HttpConfiguration httpConfig)
        {
            _httpConfig = httpConfig;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<DALModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<MetricsWebApiModule>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(_httpConfig);

            builder.RegisterType<GlobalExceptionLogger>();            

            base.Load(builder);
        }
    }
}