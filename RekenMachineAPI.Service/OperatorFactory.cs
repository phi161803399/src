using RekenMachineAPI.Service.Operators;
using System;

namespace RekenMachineAPI.Domain
{
    public interface IOperatorFactory
    {
        Operator Resolve(Expression expression);
    }
    class OperatorFactory : IOperatorFactory
    {
        public Operator Resolve(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
