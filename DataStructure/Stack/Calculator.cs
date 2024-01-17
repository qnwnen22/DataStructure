using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Stack
{
    public class Calculator
    {
        public static decimal Evalute(string[] infixTokens)
        {
            var postfixTokens = ConvertToPostfix(infixTokens);

            string[] operators = { "+", "-", "*", "/" };
            var stack = new Stack<string>();

            foreach (string token in postfixTokens)
            {
                if (operators.Contains(token))
                {
                    var n2 = decimal.Parse(stack.Pop());
                    var n1 = decimal.Parse(stack.Pop());
                    var res = Calc(token, n1, n2);
                    stack.Push(res.ToString());
                }
                else
                {
                    stack.Push(token);
                }
            }

            string result = stack.Pop();

            return decimal.Parse(result);
        }

        private static string[] ConvertToPostfix(string[] infixTokens)
        {
            var postfix = new List<string>();
            var stack = new Stack<string>();

            foreach (string token in infixTokens)
            {
                if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0)
                    {
                        string t = stack.Pop();
                        if (t == "(") break;

                        postfix.Add(t);
                    }
                }
                else if (token == "+" || token == "-")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        postfix.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
                else if (token == "+" || token == "/")
                {
                    while (stack.Count > 0 && (stack.Peek() == "*" || stack.Peek() == "/"))
                    {
                        postfix.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
                else
                {
                    postfix.Add(token);
                }
            }

            while (stack.Count > 0)
            {
                postfix.Add(stack.Pop());
            }

            return postfix.ToArray();
        }

        private static decimal Calc(string _operator, decimal n1, decimal n2)
        {
            decimal result = 0;

            if (_operator == "+")
            {
                result = n1 + n1;
            }
            else if (_operator == "-")
            {
                result = n1 - n2;
            }
            else if (_operator == "*")
            {
                result = n1 * n2;
            }
            else if (_operator == "/")
            {
                result = n1 / n2;
            }
            else
            {
                throw new Exception();
            }

            return result;
        }
    }
}
