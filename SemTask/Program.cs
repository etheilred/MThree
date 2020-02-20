using System;
using System.IO;

namespace SemTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("> ");
                    Lexer lexer = new Lexer(new StringReader(Console.ReadLine() ?? throw new ArgumentNullException()));
                    Parser parser = new Parser(lexer);
                    RootNode ast = parser.Parse();
                    Console.WriteLine(ast);
                    Evaluator repl = new Evaluator(ast);
                    Console.WriteLine(repl.Visit(ast));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Empty string");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        class U { }
        class B { }
        class C : B { }
        class D : C { }
        private static void A(U a) => Console.WriteLine("U");
        private static void A(B a) => Console.WriteLine("B");
        private static void A(D a) => Console.WriteLine("D");
        private static void A(dynamic a) => A(a);
    }
}