using System.Linq;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    internal class DivisionOperator : Operator
    {
        public override CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes)
        {
            return calculationTypes.SingleOrDefault(x => x.Name == "division");
        }
    }
}