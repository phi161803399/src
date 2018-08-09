using System;

namespace RekenMachineAPI.Domain
{
    public enum OperationType
        {
            Product = 1, Division = 2, Addition = 3, Subtraction = 4
        }
    [Flags]
    public enum OperationTypeFlags
    {
        Product = 1, Division = 2, Addition = 4, Subtraction = 8
    }

}