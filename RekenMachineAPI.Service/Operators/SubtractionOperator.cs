using System.Linq;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    internal class SubtractionOperator : Operator
    {
        public override CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes)
        {
            return calculationTypes.SingleOrDefault(x => x.Name == "subtraction");
        }
    }
}