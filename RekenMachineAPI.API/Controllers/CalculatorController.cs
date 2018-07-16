using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RekenMachineAPI.DAL;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Service;

namespace RekenMachineAPI.API.Controllers
{
    public class CalculatorController : BaseApiController
    {
        private readonly CalculationService _calculationService;
        public CalculatorController(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        [HttpPost, Route]
        public async Task<IHttpActionResult> Post(string input)
        {
            _calculationService.Calculate(input);
            return Ok();
        }
    }
}
