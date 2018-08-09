using RekenMachineAPI.Domain;
using RekenMachineAPI.Service.Calculators;
using RekenMachineAPI.Service.Operators;
using System;

namespace RekenMachineAPI.Service
{
    public interface ICalculatorService
    {
        Expression Calculate(string input);
    }
    public class CalculatorService : ICalculatorService
    {
        private Calculator _calculator;
        private Operator _operator;
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly IParseService _parseService;
        private readonly IOperatorFactory _operatorFactory;
        private readonly IService<Calculation> _calculationService;
        private readonly IService<CalculationType> _calculationTypeService;


        public CalculatorService(IParseService parseService, IOperatorFactory operatorFactory, ICalculatorFactory calculatorFactory, IService<Calculation> calculationService, IService<CalculationType> calculationTypeService)
        {
            _parseService = parseService;
            _operatorFactory = operatorFactory;
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
            calculation.CalculationString = expression.ExpressionAsString;
            calculation.Value = expression.Val;
            calculation.CalculationType = DetermineCalculationType(expression);

            _calculationService.Add(calculation);
            _calculationService.SaveChangesAsync();
        }

        private CalculationType DetermineCalculationType(Expression expression)
        {
            OperationTypeFlags ops = 0;
            StoreOperator2(expression, ref ops);
            var calculationTypes = _calculationTypeService.GetEf();

            _operator = _operatorFactory.Resolve(ops);
            return _operator.GetCalculationType(calculationTypes);
        }
        private void StoreOperator2(Expression expression, ref OperationTypeFlags ops)
        {
            if (expression.RightHand.Operation != 0)
                StoreOperator2(expression.RightHand, ref ops);
            ops |= expression.Operation;
        }
    }
}