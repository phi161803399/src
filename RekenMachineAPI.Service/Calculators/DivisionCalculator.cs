namespace RekenMachineAPI.Domain.Calculators
{
    public class DivisionCalculator : Calculator
    {
        public override decimal Calculate(Expression expression)
        {
            EnsureRightHandSide(expression);

            return expression.LeftHand.Val / expression.RightHand.Val;
        }
        public DivisionCalculator(CalculatorFactory calculatorFactory) : base(calculatorFactory)
        {
        }
    }
}
