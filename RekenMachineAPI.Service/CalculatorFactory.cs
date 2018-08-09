﻿using System;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Service.Calculators;

namespace RekenMachineAPI.Service
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
            throw new NotImplementedException($"operation {expression.Operation} is not implemented");
        }
    }
}
