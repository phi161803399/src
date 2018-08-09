using RekenMachineAPI.Domain;
using RekenMachineAPI.Service.Calculators;

namespace RekenMachineAPI.Service
{
    public interface ICalculatorFactory
    {
        Calculator Resolve(Expression expression);
    }
}