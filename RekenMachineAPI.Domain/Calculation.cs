using System;

namespace RekenMachineAPI.Domain
{
    public class Calculation
    {
        public int Id { get; set; }
        public string CalculationString { get; set; }
        public DateTime Created { get; set; }
        public decimal Value { get; set; }
        public OperationType OperationType { get; set; }
    }
}