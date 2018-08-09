using RekenMachineAPI.Domain;
using RekenMachineAPI.Service.Operators;

namespace RekenMachineAPI.Service
{
    public interface IOperatorFactory
    {
        Operator Resolve(OperationType ops);
    }
    public class OperatorFactory : IOperatorFactory
    {
        public Operator Resolve(OperationType ops)
        {
            if (ops == OperationType.Addition)
                return new AdditionOperator();
            if (ops == OperationType.Subtraction)
                return new SubtractionOperator();
            if (ops == OperationType.Product)
                return new ProductOperator();
            if (ops == OperationType.Division)
                return new DivisionOperator();
            return new MixedOperator();
        }
    }
}
