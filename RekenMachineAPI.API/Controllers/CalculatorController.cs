﻿using System;
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
        private readonly ICalculatorService _calculatorService;
        private readonly IService<Calculation> _calculationService;

        public CalculatorController(ICalculatorService calculatorService, IService<Calculation> calculationService)
        {
            _calculatorService = calculatorService;
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
            var calculation = await _calculationService.GetAsyncEf(id);

            if (calculation == null)
                return NotFound();

            return Ok(calculation);
        }


        [HttpPost, Route]
        public async Task<IHttpActionResult> Post(Calculation calculation)
        {
            _calculatorService.Calculate(calculation.CalculationString);

//            _calculationService.Add(calculation);
//            await _calculationService.SaveChangesAsync();
            return Ok(calculation.CalculationString + " added to database");
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
            var calculationToDelete = await _calculationService.GetAsyncEf(id);

            if (calculationToDelete == null)
                return NotFound();

            _calculationService.Delete(calculationToDelete);
            await _calculationService.SaveChangesAsync();

            return Ok();
        }
    }
}
