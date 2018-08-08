using RekenMachineAPI.Domain;
using RekenMachineAPI.Domain.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace RekenMachineAPI.Service
{
    public interface ICalculatorService
    {
        Expression Calculate(string input);
    }
    public class CalculatorService : ICalculatorService
    {
        private Calculator _calculator;
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly IParseService _parseService;
        private readonly IService<Calculation> _calculationService;
        private readonly IService<CalculationType> _calculationTypeService;


        public CalculatorService(IParseService parseService, ICalculatorFactory calculatorFactory, IService<Calculation> calculationService, IService<CalculationType> calculationTypeService)
        {
            _parseService = parseService;
            _calculatorFactory = calculatorFactory;
            _calculationService = calculationService;
            _calculationTypeService = calculationTypeService;
        }

        public Expression Calculate(string input)
        {
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
            //calculation.inputString
            calculation.CalculationString = expression.ExpressionAsString;
            calculation.Value = expression.Val;
            calculation.CalculationType = DetermineCalculationType(expression);

            _calculationService.Add(calculation);
            _calculationService.SaveChangesAsync();
        }

        private CalculationType DetermineCalculationType(Expression expression)
        {
            // in expressie: vind alle verschillende operaties (recursief)
            List<OperationType> listOfOperationTypes = new List<OperationType>();
            StoreOperator(expression, listOfOperationTypes);

            // dan haal calculationtypes op
            var calculationTypes = _calculationTypeService.GetEf();

            // Factory maken zoals CalculatorFactory
            switch (expression.Operation)
            {
                case OperationType.Addition: return calculationTypes.SingleOrDefault(x => x.Name == "addition");
                case OperationType.Division: return calculationTypes.SingleOrDefault(x => x.Name == "division");
                case OperationType.Product: return calculationTypes.SingleOrDefault(x => x.Name == "product");
                case OperationType.Subtraction: return calculationTypes.SingleOrDefault(x => x.Name == "subtraction");
                default: return calculationTypes.SingleOrDefault(x => x.Name == "mixed");
            }
        }

        private void StoreOperator(Expression expression, List<OperationType> listOfOperationTypes)
        {
            if (expression.RightHand.Operation != 0)
                StoreOperator(expression.RightHand, listOfOperationTypes);
            listOfOperationTypes.Add(expression.Operation);
        }
    }
}