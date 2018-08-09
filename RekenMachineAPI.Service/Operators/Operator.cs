using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service.Operators
{
    public abstract class Operator
    {
        public abstract CalculationType GetCalculationType(CalculationType calculationTypes);
    }
}