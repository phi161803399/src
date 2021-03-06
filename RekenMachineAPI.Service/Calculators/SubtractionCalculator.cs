﻿namespace RekenMachineAPI.Domain.Calculators
{
    public class SubtractionCalculator : Calculator
    {
        public override decimal Calculate(Expression expression)
        {
            EnsureRightHandSide(expression);

            return expression.LeftHand.Val - expression.RightHand.Val;
        }

        public SubtractionCalculator(CalculatorFactory calculatorFactory) : base(calculatorFactory)
        {
        }
    }
}
