using System;
using System.Data.Entity.Infrastructure;
using RekenMachineAPI.Domain.Calculators;

namespace RekenMachineAPI.Domain
{
    public class CalculatorFactory : ICalculatorFactory
    {
        public Calculator Resolve(Expression expression)
        {
            if (expression.Operation == OperationType.Product)
                return new ProductCalculator(this);
            else if (expression.Operation == OperationType.Division)
                return new DivisionCalculator(this);
            else if (expression.Operation == OperationType.Subtraction)
                return new SubtractionCalculator(this);
            else if (expression.Operation == OperationType.Addition)
                return new AdditionCalculator(this);
            throw new NotImplementedException(String.Format("operation {0} is not implemented", expression.Operation));
        }
    }
}
