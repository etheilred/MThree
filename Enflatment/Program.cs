using System;

namespace Enflatment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int inpCount = 0;
            do
            {
                try
                {
                    Console.Write("> ");
                    string s = Console.ReadLine();
                    Lexer lexer = new Lexer(s);
                    Parser parser = new Parser(lexer);
                    ArrayItem item = parser.ParseArrayItem();
                    Console.WriteLine(item);
                    Console.WriteLine(new ArrayItem(Item.GetYield(item)));
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (true);
        }
    }
}
