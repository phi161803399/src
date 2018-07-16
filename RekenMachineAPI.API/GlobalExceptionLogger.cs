using System.Web.Http.ExceptionHandling;
using PCore.Logging;

namespace RekenMachineAPI.API
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private readonly ILogger _logger;

        public GlobalExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }
        public override void Log(ExceptionLoggerContext context)
        {            
            _logger.Error(context.Exception);
        }
    }
}