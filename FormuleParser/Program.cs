using Antlr4.Runtime;
using System;

namespace FormuleParser
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("> ");
                string expr = Console.ReadLine();
                AntlrInputStream inputStream = new AntlrInputStream(expr);
                ExprLexer exprLexer = new ExprLexer(inputStream);
                CommonTokenStream tokenStream = new CommonTokenStream(exprLexer);
                ExprParser exprParser = new ExprParser(tokenStream);
                exprParser.BuildParseTree = true;
                var cst = exprParser.compileUnit();
                try
                {
                    var ast = new BuildAstVisitor().VisitCompileUnit(cst);
#if DEBUG
                    PrintAst(ast, 0);
#endif
                    Console.WriteLine($"= {new AstEvaluator().Visit(ast)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
#if DEBUG
        static void PrintAst(ExprNode node, int ind)
        {
            if (node is NumberNode)
            {
                for (int i = 0; i < ind; ++i) Console.Write("  ");
                Console.WriteLine(node);
                return;
            }

            for (int i = 0; i < ind; ++i) Console.Write("  ");
            Console.WriteLine(node);
            if (node is FuncNode)
                PrintAst(((FuncNode)node).Argument, ind + 1);
            if (node is NegNode)
                PrintAst(((NegNode)node).InnerNode, ind + 1);
            if (node is InfixNode)
            {
                PrintAst(((InfixNode)node).Left, ind + 1);
                PrintAst(((InfixNode)node).Right, ind + 1);
            }
        }
#endif
    }
}
