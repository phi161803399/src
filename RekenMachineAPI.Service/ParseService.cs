using RekenMachineAPI.Domain;
using System;
using System.Text.RegularExpressions;

namespace RekenMachineAPI.Service
{
    public class ParseService : IParseService
    {

        public Expression Parse(string input)
        {
            Expression expression = new Expression(input);
            if (TryparseExpressionBody(input, expression, out var message))
            { 
                return expression;
            }

            if (TryParseExpressionEnd(input, out var value))
            {
                if (value != null) expression.Val = value.Value;
                return expression;
            }
            throw new Exception(message);
        }

        private bool TryparseExpressionBody(string input, Expression expression, out string message)
        {
            string matchPattern = @"^([0-9.]+)\s*(\D+)\s*([\.\(\)0-9*\D]+)";
            var x = Regex.Match(input, matchPattern);

            if (x.Success)
            {
                expression.LeftHand = Parse(x.Groups[1].ToString().Trim());
                expression.Operation = GetOperator(x.Groups[2].ToString().Trim());
                expression.RightHand = Parse(x.Groups[3].ToString().Trim());
                message = $"Parsing {input}";
            }
            else
            {
                message = $"Unable to parse '{input}'.\r\n" +
                          $" Use operators like 'keer', 'delen', 'plus', 'min' like '3plus5', '7keer3plus10'\r\n";
            }

            return x.Success;
        }

        private bool TryParseExpressionEnd(string input, out decimal? output)
        {
            string endPattern = @"^([0-9.]+)$";
            var y = Regex.Match(input, endPattern);
            if (y.Success)
                output = decimal.Parse(y.Groups[1].ToString());
            else
                output = null;

            return y.Success;
        }

        private OperationTypeFlags GetOperator(string op)
        {
            switch (op)
            {
                case "keer":
                    return OperationTypeFlags.Product;
                case "delen":
                    return OperationTypeFlags.Division;
                case "plus":
                    return OperationTypeFlags.Addition;
                case "min":
                    return OperationTypeFlags.Subtraction;
            }

            throw new NotImplementedException("string contains unidentified Operation");
        }
    }
}
