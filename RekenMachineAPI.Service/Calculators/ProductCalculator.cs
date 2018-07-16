namespace RekenMachineAPI.Domain.Calculators
{
    public class ProductCalculator : Calculator
    {
        public override decimal Calculate(Expression expression)
        {
            EnsureRightHandSide(expression);

            return expression.LeftHand.Val * expression.RightHand.Val;
        }
        public ProductCalculator(CalculatorFactory calculatorFactory) : base(calculatorFactory)
        {
        }
    }
}
