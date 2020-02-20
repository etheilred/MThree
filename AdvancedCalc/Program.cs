using Antlr4.Runtime;
using System;
using System.IO;

namespace AdvancedCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                do
                {
                    Console.Write("> ");
                    string s = Console.ReadLine();
                    try
                    {
                        var ast = GetAst(s);
                        Console.WriteLine(ast);
                        CodeGenAstVisitor cd = new CodeGenAstVisitor();
                        cd.Visit(ast);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                } while (true);

            switch (args.Length)
            {
                case 1 when File.Exists(args[0]):
                    try
                    {
                        var ast = GetAst(File.ReadAllText(args[0]));
                        // Console.WriteLine(ast);
                        File.WriteAllText(args[0] + ".cmp", ast.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case 1:
                    Console.WriteLine("No such file");
                    break;
            }
        }

        static AstNode GetAst(string s)
        {
            AntlrInputStream inputStream = new AntlrInputStream(s);
            ExprLexer exprLexer = new ExprLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(exprLexer);
            ExprParser exprParser = new ExprParser(tokenStream) { BuildParseTree = true };
            var cst = exprParser.compileUnit();
            if (exprParser.NumberOfSyntaxErrors != 0)
            {
                throw new ArgumentException("invalid syntax");
            }
            var ast = new AstBuilderVisitor().Visit(cst);
            return ast;
        }
    }
}
