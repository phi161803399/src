using System.Linq;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    public class AdditionOperator : Operator
    {
        public override CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes)
        {
            return calculationTypes.SingleOrDefault(x => x.Name == "addition");
        }
    }
}
