using System;

namespace RecDescend
{
    /// <summary>
    /// Provides parsing tools for grammar:
    /// S ::= A + S | A - S | A
    /// A ::= (S) | N
    /// N ::= [0-9]N | [0-9]
    /// </summary>
    class Parser2 : ParserBase
    {
        public Parser2(string inp) : base(inp) { }

        public bool IsValid()
        {
            try
            {
                return S() && EOF;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private bool S()
        {
            switch (Peek())
            {
                case '(':
                case '-':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    bool t = A();
                    if (EOF) return t;
                    if (t && (Peek() == '+' || Peek() == '-'))
                    {
                        char tmp = Peek();
                        return Match(Peek()) && S() && SemanticCall(tmp.ToString() + " ");
                    }
                    else return true;
            }

            return false;
        }

        private bool B()
        {
            switch (Peek())
            {
                case '-': return Match('-') && B() && SemanticCall("#- ");
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': return N();
                case '(': return Match('(') && S() && Match(')');
                default: return false;
            }
        }

        private bool A()
        {
            switch (Peek())
            {
                case '(':
                case '-':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    bool t = B();
                    if (EOF) return t;
                    if (t && (Peek() == '*' || Peek() == '/'))
                    {
                        char tmp = Peek();
                        return Match(Peek()) && A() && SemanticCall(tmp.ToString() + " ");
                    }
                    else return true;
            }

            return false;
        }

        private bool N()
        {
            while (!EOF && Peek() <= '9' && Peek() >= '0')
            {
                SemanticCall(Peek().ToString());
                Match(Peek());
            }

            SemanticCall(" ");
            return true;
        }
    }
}