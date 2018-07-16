using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using RekenMachineAPI.API;
using RekenMachineAPI.Domain;

[assembly: OwinStartup(typeof(Startup))]

namespace RekenMachineAPI.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();

            var container = DependenciesConfig.Configure(httpConfig);
            container.Resolve<MapperConfiguration>().AssertConfigurationIsValid();

            ConfigureOwin(httpConfig, container);
            ConfigureAppBuilder(app, httpConfig, container);
        }

        public static void ConfigureAppBuilder(IAppBuilder app, HttpConfiguration httpConfig, IContainer container)
        {
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfig);
            app.UseWebApi(httpConfig);
        }

        public static void ConfigureOwin(HttpConfiguration httpConfig, IContainer container)
        {
            //Routing
            httpConfig.MapHttpAttributeRoutes();

            //Deps
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //Formatters
            httpConfig.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            httpConfig.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            httpConfig.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            httpConfig.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            httpConfig.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //Swagger
            SwaggerConfig.Register(httpConfig);

            //Cors
            var corsAttribute = new EnableCorsAttribute(ConfigurationManager.AppSettings["cors-origins"], "*", "*")
            {
                SupportsCredentials = true
            };
            httpConfig.EnableCors(corsAttribute);

            //Error handling
            httpConfig.Services.Add(typeof(IExceptionLogger), container.Resolve<GlobalExceptionLogger>());
            httpConfig.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}