using System.Linq;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    internal class ProductOperator : Operator
    {
        public override CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes)
        {
            return calculationTypes.SingleOrDefault(x => x.Name == "product");
        }
    }
}