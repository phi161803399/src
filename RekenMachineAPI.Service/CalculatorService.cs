using RekenMachineAPI.Domain;
using RekenMachineAPI.Domain.Calculators;
using System;
using System.Linq;

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

            OperationTypeFlags ops = 0;
            StoreOperator2(expression, ref ops);


            //in expressie: vind alle verschillende operaties(recursief)
//            List<OperationType> listOfOperationTypes = new List<OperationType>();
//            StoreOperator(expression, listOfOperationTypes);




            // dan haal calculationtypes op
            var calculationTypes = _calculationTypeService.GetEf();

            // Factory maken zoals CalculatorFactory

            switch (expression.Operation)
            {
                case OperationTypeFlags.Addition: return calculationTypes.SingleOrDefault(x => x.Name == "addition");
                case OperationTypeFlags.Division: return calculationTypes.SingleOrDefault(x => x.Name == "division");
                case OperationTypeFlags.Product: return calculationTypes.SingleOrDefault(x => x.Name == "product");
                case OperationTypeFlags.Subtraction: return calculationTypes.SingleOrDefault(x => x.Name == "subtraction");
                default: return calculationTypes.SingleOrDefault(x => x.Name == "mixed");
            }
        }

//        private void StoreOperator(Expression expression, List<OperationType> listOfOperationTypes)
//        {
//
//            if (expression.RightHand.Operation == OperationType.Addition 
//                || expression.RightHand.Operation == OperationType.Subtraction 
//                || expression.RightHand.Operation == OperationType.Product 
//                || expression.RightHand.Operation == OperationType.Division)
//                StoreOperator(expression.RightHand, listOfOperationTypes);
//            listOfOperationTypes.Add(expression.Operation);
//        }

        private void StoreOperator2(Expression expression, ref OperationTypeFlags ops)
        {
            if (expression.RightHand.Operation != 0)
                StoreOperator2(expression.RightHand, ref ops);
            ops |= expression.Operation;
        }
    }
}