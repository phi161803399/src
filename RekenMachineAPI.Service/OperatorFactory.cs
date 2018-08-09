using RekenMachineAPI.Domain;
using RekenMachineAPI.Service.Operators;

namespace RekenMachineAPI.Service
{
    public interface IOperatorFactory
    {
        Operator Resolve(OperationTypeFlags ops);
    }
    public class OperatorFactory : IOperatorFactory
    {
        public Operator Resolve(OperationTypeFlags ops)
        {
            if (ops == OperationTypeFlags.Addition)
                return new AdditionOperator();
            if (ops == OperationTypeFlags.Subtraction)
                return new SubtractionOperator();
            if (ops == OperationTypeFlags.Product)
                return new ProductOperator();
            if (ops == OperationTypeFlags.Division)
                return new DivisionOperator();
            return new MixedOperator();
        }
    }

    
}
