using System.Linq;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    public abstract class Operator
    {
        public abstract CalculationType GetCalculationType(IQueryable<CalculationType> calculationTypes);
    }
}