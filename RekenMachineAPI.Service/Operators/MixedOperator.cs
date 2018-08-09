using RekenMachineAPI.Domain;
using System.Linq;

namespace RekenMachineAPI.Service.Operators
{
    public class MixedOperator: Operator
    {
        public override CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes)
        {
            return calculationTypes.SingleOrDefault(x => x.Name == "mixed");
        }
    }
}
