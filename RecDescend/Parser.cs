using System;

namespace RecDescend
{
    /// <summary>
    /// Provides parsing tools for grammar (prefix expressions):
    /// S ::= + S S | - S S | a
    /// </summary>
    class Parser : ParserBase
    {
        public Parser(string inp) : base(inp)
        { }

        public bool IsValid()
        {
            try
            {
                return S() && Current == Input.Length;
            }
            catch
            {
                return false;
            }
        }

        private bool S()
        {
            switch (Peek())
            {
                case 'a': Console.Write('a'); return Match('a');
                case '+':
                case '-':
                    char c = Peek();
                    bool t = Match(Peek()) && S() && S();
                    Console.Write(c);
                    return t;
            }
            return false;
        }
    }
}