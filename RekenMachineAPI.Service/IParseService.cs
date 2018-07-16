using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service
{
    public interface IParseService
    {
        Expression Parse(string input);
    }
}