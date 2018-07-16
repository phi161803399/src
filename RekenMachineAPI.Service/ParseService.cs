using System;
using System.Text;
using System.Text.RegularExpressions;
using RekenMachineAPI.Domain;

namespace RekenMachineAPI.Service
{
    public class ParseService : IParseService
    {

        public Expression Parse(string input)
        {
            Expression expression = new Expression(input);
            decimal? value;
            string message;
            //todo afhandelen van niet-succes
            if (TryparseExpressionBody(input, expression, out message))
            {
                // when expression is like '3+5' method will parse into two new expressions
                return expression;
            }

            if (TryParseExpressionEnd(input, out value))
            {
                // when expression is a decimal number like '3' this method will return an expression with Val = 3
                expression.Val = value.Value;
                return expression;
            }


            return expression;
        }

        private bool TryparseExpressionBody(string input, Expression expression, out string message)
        {
            string matchPattern = @"^([0-9.]+)\s*(\D+)\s*([\.\(\)0-9*\D]*)";
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
            string endPattern = @"^([0-9.]*)$";
            var y = Regex.Match(input, endPattern);
            if (y.Success)
                //tryparse
                output = decimal.Parse(y.Groups[1].ToString());
            else
                output = null;

            return y.Success;
        }

        private OperationType GetOperator(string op)
        {
            switch (op)
            {
                case "keer":
                    return OperationType.Product;
                case "delen":
                    return OperationType.Division;
                case "plus":
                    return OperationType.Addition;
                case "min":
                    return OperationType.Subtraction;
            }

            throw new NotImplementedException("string contains unidentified Operation");
        }
    }
}
