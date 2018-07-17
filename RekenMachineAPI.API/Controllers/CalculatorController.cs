using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RekenMachineAPI.DAL;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Service;

namespace RekenMachineAPI.API.Controllers
{
        [RoutePrefix("api/calculators")]
        public class CalculatorController : BaseApiController
        {
            private readonly IService<Calculation> _calculationService;

            public CalculatorController(IService<Calculation> calculationService)
            {
                _calculationService = calculationService;
            }

            [HttpGet, Route]
            public async Task<IHttpActionResult> GetAll(string sort = null)
            {
                return Ok(await _calculationService.GetEf().ToListAsync());
            }

            [HttpGet, Route("{id}")]
            public async Task<IHttpActionResult> Get(int id)
            {
                var person = await _calculationService.GetAsyncEf(id);

                if (person == null)
                    return NotFound();

                return Ok(person);
            }


            [HttpPost, Route]
            public async Task<IHttpActionResult> Post(Calculation calculation)
            {
                _calculationService.Add(calculation);
                await _calculationService.SaveChangesAsync();
                return Ok();
            }

            [HttpPut, Route("{id}")]
            public async Task<IHttpActionResult> Put(int id, Calculation calculation)
            {
                var calculationToUpdate = await _calculationService.GetAsyncEf(id);

                if (calculationToUpdate == null)
                    return NotFound();

                calculationToUpdate.CalculationString = calculation.CalculationString;
                await _calculationService.SaveChangesAsync();

                return Ok();
            }

            [HttpDelete, Route("{id}")]
            public async Task<IHttpActionResult> Delete(int id)
            {
                var personToDelete = await _calculationService.GetAsyncEf(id);

                if (personToDelete == null)
                    return NotFound();

                _calculationService.Delete(personToDelete);
                await _calculationService.SaveChangesAsync();

                return Ok();
            }
        }
}
