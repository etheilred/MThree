using System;
using System.Collections.Generic;

namespace RecDescend
{
    class PolizEvaluator
    {
        private readonly string[] _tokens;

        private Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            {"+", (a, b) => a + b},
            {"*", (a, b) => a * b},
            {"/", (a, b) => a / b},
            {"-", (a, b) => a - b},
            {"^", (a, b) => Math.Pow(a, b)},
            {"==", (a, b) => a == b ? 1 : 0},
            {"!=", (a, b) => a != b ? 1 : 0},
            {">=", (a, b) => a >= b ? 1 : 0},
            {"<=", (a, b) => a <= b ? 1 : 0},
            {">", (a, b) => a > b ? 1 : 0},
            {"<", (a, b) => a < b ? 1 : 0},
        };

        private Dictionary<string, Func<double, double>> unaryOperations = new Dictionary<string, Func<double, double>>()
        {
            {"#-", (a) => -a}
        };

        public PolizEvaluator(string[] tokens)
        {
            _tokens = tokens;
        }

        public double Evaluate()
        {
            Stack<double> valStack = new Stack<double>();
            double a, b, c;
            foreach (var token in _tokens)
            {
                if (operations.ContainsKey(token))
                {
                    b = valStack.Pop();
                    a = valStack.Pop();
                    valStack.Push(operations[token](a, b));
                }
                else if (unaryOperations.ContainsKey(token))
                {
                    a = valStack.Pop();
                    valStack.Push(unaryOperations[token](a));
                }
                else if (token == "if")
                {
                    c = valStack.Pop();
                    b = valStack.Pop();
                    a = valStack.Pop();
                    if (a != 0)
                        valStack.Push(b);
                    else valStack.Push(c);
                }
                else valStack.Push(int.Parse(token));
            }
            if (valStack.Count != 1)
                throw new ArgumentException("Invalid expression");
            return valStack.Pop();
        }
    }
}