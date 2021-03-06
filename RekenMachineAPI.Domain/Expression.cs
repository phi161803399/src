﻿using System;
using System.Security.Permissions;

namespace RekenMachineAPI.Domain
{
    public class Expression
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Expression LeftHand { get; set; }
        public Expression RightHand { get; set; }
        public OperationType Operation { get; set; }

        public decimal Val { get ; set; }

        public string ExpressionAsString { get; set; }

        public Expression(string input)
        {
            DateCreated = DateTime.Now;
            ExpressionAsString = input;
        }

        public override string ToString()
        {
            return $"{ExpressionAsString} = {Val}";
        }
    }
}
