using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Domain.Calculators;

namespace RekenMachineAPI.Service
{
    public interface ICalculationService
    {
        Expression Calculate(string input);
    }
    public class CalculationService : ICalculationService
    {
        private Calculator _calculator;
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly IParseService _parseService;
        private readonly IService<Calculation> _calculationService;

        public CalculationService(IParseService parseService, ICalculatorFactory calculatorFactory, IService<Calculation> calculationService)
        {
            _parseService = parseService;
            _calculatorFactory = calculatorFactory;
            _calculationService = calculationService;
        }

        public Expression Calculate(string input)
        {
            StringBuilder log = new StringBuilder();
            Expression expression = _parseService.Parse(input);
            _calculator = _calculatorFactory.Resolve(expression);
            expression.Val = _calculator.Calculate(expression);

            LogExpression(expression);
            return expression;
        }

        private void LogExpression(Expression expression)
        {
            Calculation calculation = new Calculation
            {
                Created = DateTime.Now
            };
            // mapping
            calculation.CalculationString = expression.ExpressionAsString;
            calculation.Value = expression.Val;
            calculation.CalculationTypeId = (int)expression.Operation;

            _calculationService.Add(calculation);
            _calculationService.SaveChangesAsync();
            


//            throw new NotImplementedException();
        }
    }
}