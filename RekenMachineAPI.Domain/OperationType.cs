using System;

namespace RekenMachineAPI.Domain
{
    [Flags]
    public enum OperationType
    {
        Product = 1, Division = 2, Addition = 4, Subtraction = 8
    }

}