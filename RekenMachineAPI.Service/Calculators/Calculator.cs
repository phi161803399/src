using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Calculators
{
    public abstract class Calculator
    {
        private readonly CalculatorFactory _calculatorFactory;
        protected void EnsureRightHandSide(Expression expression)
        {
            // val moet decimal?
            if (expression.RightHand.Val == 0)
            {
                var calculator = _calculatorFactory.Resolve(expression.RightHand);
                expression.RightHand.Val = calculator.Calculate(expression.RightHand);
            }
        }
        protected Calculator(CalculatorFactory calculatorFactory)
        {
            _calculatorFactory = calculatorFactory;
        }

        public abstract decimal Calculate(Expression expression);
    }
}
