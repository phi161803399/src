using RekenMachineAPI.Domain.Calculators;

namespace RekenMachineAPI.Domain
{
    public interface ICalculatorFactory
    {
        Calculator Resolve(Expression expression);
    }
}