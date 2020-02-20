using System;
using System.IO;

namespace Partiality
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("> ");
                ListExprLexer listExprLexer = new ListExprLexer(new StringReader(Console.ReadLine() ?? throw new InvalidOperationException()));
                ListExprParser listExprParser = new ListExprParser(listExprLexer);
                try
                {
                    AstNode ast = listExprParser.Parse();
                    Console.WriteLine(ast);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (true);
        }
    }
}
