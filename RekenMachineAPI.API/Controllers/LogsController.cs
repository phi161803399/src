using System;
using System.Threading.Tasks;
using System.Web.Http;
using PCore.Logging;

namespace RekenMachineAPI.API.Controllers
{
    [RoutePrefix("api/logs")]
    public class LogsController : BaseApiController
    {
        private readonly ILogger _logger;

        public LogsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost, Route]
        public IHttpActionResult Post(string error)
        {
            _logger.Error(new JavascriptException(error));
            return Ok();
        }
    }

    public class JavascriptException : Exception
    {
        public JavascriptException(string message) : base(message)
        {
        }
    }
}