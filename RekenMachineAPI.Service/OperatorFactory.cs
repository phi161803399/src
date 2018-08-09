using System;
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
            else if (ops == OperationTypeFlags.Subtraction)
                return new SubtractionOperator();
            else if (ops == OperationTypeFlags.Product)
                return new ProductOperator();
            else if (ops == OperationTypeFlags.Division)
                return new DivisionOperator();
            else
                return new MixedOperator();
            throw new NotImplementedException();
        }
    }

    
}
