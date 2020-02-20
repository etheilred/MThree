using System;
using System.Linq;

/*
 *********************************
 *   S ::= + S S | - S S | a     *
 *********************************
 * S -> + S S -> + + S S S | + + a a a
 */

/*
 * S ::= A + S | A - S | A
 * A ::= B * A | B / A | B
 * B ::= (S) | N | -B
 * N ::= [0-9]N | [0-9]
 *
 * S -> A + S -> (S) + A -> (A) + a -> (a) + a
 */

namespace RecDescend
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0;
            do
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                Lexer lexer = new Lexer(s);
                if (!lexer.IsValid())
                {
                    Console.WriteLine("Wrong");
                    continue;
                }
                ParserIfStr parser = new ParserIfStr(s.Replace(" ", ""));
                bool t = parser.IsValid();
                Console.WriteLine($"[{++cnt}] {(t ? "OK" : "Error")}");
                if (!t) continue;
                Console.WriteLine(parser.Poliz);
                var tokens = parser.Poliz.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
                try
                {
                    Console.WriteLine($"= {new PolizEvaluator(tokens.ToArray()).Evaluate()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Runtime error: " + e.Message);
                }
            } while (true);
        }
    }
}
