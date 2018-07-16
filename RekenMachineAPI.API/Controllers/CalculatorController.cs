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
        [HttpGet, Route("api/calculator")]
//        public async Task<IHttpActionResult> Get()
//        {
////            using (var ctx = new Context())
////            {
////                var calculations = ctx.Expressions.ToList();
////                return Ok(calculations);
////            }
//        }

        [HttpPost, Route("api/calculator/{input}")]
        public async Task<IHttpActionResult> Post(string input)
        {
            return Ok();
            //using (var ctx = new Context())
            //{
            //    CalculationService calculationService = new CalculationService(new ParseService(), new CalculatorFactory());
            //    var result = calculationService.Calculate(input);
            //    var resultDto = new ExpressionDto
            //    {
            //        Id = result.Id,
            //        Calculation = result.ExpressionAsString,
            //        Created = result.DateCreated,
            //        OperationType = result.Operation,
            //        Value = result.Val
            //    };
            //    //                ctx.Expressions.Add(resultDto);
            //    ctx.Expressions.Add(result);
            //    ctx.SaveChanges();
            //    return Ok(result.ToString());
            //}
//            _sampleService.Add(sample);
//            await _sampleService.SaveChangesAsync();
//            return Ok();
        }
    }
}
