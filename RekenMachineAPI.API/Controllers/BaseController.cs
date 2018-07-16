using System.Web.Http;
using AutoMapper;

namespace RekenMachineAPI.API.Controllers
{
    public class BaseApiController : ApiController
    {
        public IMapper Mapper { get; set; }
    }
}