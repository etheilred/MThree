using System;

namespace RecDescend
{
    class ParserBase
    {
        private protected int Current;
        private protected string Input;

        private protected bool EOF
        {
            get => Current == Input.Length;
        }

        public ParserBase(string input)
        {
            Input = input;
            Current = 0;
        }

        private protected virtual bool Match(char c)
        {
            if (Current < Input.Length && Input[Current++] == c) return true;
            return false;
        }

        private protected virtual char Peek()
        {
            if (Current >= Input.Length)
                throw new ArgumentException("Invalid syntax");
            return Input[Current];
        }

        private protected virtual bool SemanticCall(string prod)
        {
            Console.Write(prod);
            return true;
        }
    }
}