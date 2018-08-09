using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Calculators
{
    public class AdditionCalculator : Calculator
    {
        public override decimal Calculate(Expression expression)
        {
            EnsureRightHandSide(expression);

            return expression.LeftHand.Val + expression.RightHand.Val;
        }

        public AdditionCalculator(CalculatorFactory calculatorFactory) : base(calculatorFactory)
        {
        }
    }
}
