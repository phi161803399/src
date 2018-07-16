using System.Web.Http;
using Swashbuckle.Application;

namespace RekenMachineAPI.API
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration httpConfig)
        {
            httpConfig
                .EnableSwagger(c => { c.SingleApiVersion("v1", "RekenMachineAPI.API"); })
                .EnableSwaggerUi(c => { });
        }
    }
}