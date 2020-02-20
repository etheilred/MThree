using System;

namespace RecDescend
{
    /*
     * S ::= if ( F ) then S else S | F
     * F ::= E == F | E < F | E > F | E != F | E <= F | E >= F | E
     * E ::= A + E | A - E | A
     * A ::= B * A | B / A | B
     * B ::= C ^ B | C
     * C ::= ( S ) | -C | N
     * N ::= [0-9]N | [0-9]
     */

    /*
     * if ( E ) then S else S --(to poliz)--> E S S if 
     */
    class ParserIf : ParserBase
    {
        public ParserIf(string inp) : base(inp) { }

        public bool IsValid()
        {
            try
            {
                S();
                // Console.WriteLine($"is eof? --- {EOF}");
                return EOF;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void B()
        {
            C();
            string ss = "";
            while (!EOF && Peek() == '^')
            {
                ss += "^ ";
                Match(Peek());
                C();
            }

            SemanticCall(ss);
        }

        public void C()
        {
            if (Peek() == '(')
            {
                if (!Match('(')) throw new ArgumentException("Invalid Syntax");
                S();
                if (!Match(')')) throw new ArgumentException("Invalid Syntax");
            }
            else if (Peek() == '-')
            {
                Match('-');
                C();
                SemanticCall("#- ");
            }
            else if (char.IsDigit(Peek()))
            {
                N();
            }
            else throw new Exception($"Unexpected token {Peek()}");
        }

        public void N()
        {
            while (!EOF && char.IsDigit(Peek()))
            {
                SemanticCall(Peek().ToString());
                Match(Peek());
            }

            SemanticCall(" ");
        }

        public void A()
        {
            B();
            while (!EOF && (Peek() == '*' || Peek() == '/'))
            {
                char t = Peek();
                Match(Peek());
                B();
                SemanticCall(t + " ");
            }
        }

        public void E()
        {
            A();
            while (!EOF && (Peek() == '-' || Peek() == '+'))
            {
                char t = Peek();
                Match(Peek());
                A();
                SemanticCall(t + " ");
            }
        }

        public void F()
        {
            E();
            while (!EOF && (Peek() == '!' || Peek() == '=' || Peek() == '>' || Peek() == '<'))
            {
                if (Peek() == '!')
                {
                    Match(Peek());
                    Match('=');
                    E();
                    SemanticCall("!= ");
                }
                else if (Peek() == '=')
                {
                    Match(Peek());
                    Match('=');
                    E();
                    SemanticCall("== ");
                }
                else if (Peek() == '>')
                {
                    Match(Peek());
                    if (Peek() != '=')
                    {
                        E();
                        SemanticCall("> ");
                    }
                    else
                    {
                        Match(Peek());
                        E();
                        SemanticCall(">= ");
                    }
                } else if (Peek() == '<')
                {
                    Match(Peek());
                    if (Peek() != '=')
                    {
                        E();
                        SemanticCall("<");
                    }
                    else
                    {
                        Match(Peek());
                        E();
                        SemanticCall("<=");
                    }
                }
            }
        }

        public void S()
        {
            if (Peek() == '(' || Peek() == '-' || char.IsDigit(Peek()))
            {
                F();
                return;
            }
            if (Peek() == 'i')
            {
                Match('i');
                if (Peek() == 'f')
                {
                    Match('f');
                    if (Match('('))
                    {
                        F();
                        if (!(Match(')') &&
                        Match('t') &&
                        Match('h') &&
                        Match('e') &&
                        Match('n'))) throw new Exception("Must be then");
                        S();
                        if (!(
                        Match('e') &&
                        Match('l') &&
                        Match('s') &&
                        Match('e'))) throw new Exception("Must be else");
                        S();
                    }
                }
                else throw new Exception("must be if");

                SemanticCall("if ");
            } else throw new Exception("Invalid syntax");
        }
    }
}