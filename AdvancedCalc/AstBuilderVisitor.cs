using System;
using System.Globalization;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace AdvancedCalc
{
    public class AstBuilderVisitor : ExprBaseVisitor<AstNode>
    {
        public override AstNode VisitCompileUnit(ExprParser.CompileUnitContext context)
        {
            return Visit(context.expr());
        }

        public override AstNode VisitNumExpr(ExprParser.NumExprContext context)
        {
            return new AstNode.NumNode() {Value = double.Parse(context.value.Text, CultureInfo.InvariantCulture)};
        }

        public override AstNode VisitPurenExpr(ExprParser.PurenExprContext context)
        {
            return Visit(context.expr());
        }

        public override AstNode VisitNegExpr(ExprParser.NegExprContext context)
        {
            return new AstNode.NegNode()
            {
                InnerNode = Visit(context.expr()) as AstNode.ExprNode
            };
        }

        public override AstNode VisitP0Expr(ExprParser.P0ExprContext context)
        {
            AstNode.BinaryNode node;
            switch (context.op.Type)
            {
                case ExprLexer.OP_ADD: node = new AstNode.AddNode(); break;
                case ExprLexer.OP_SUB: node = new AstNode.SubNode(); break;
                case ExprLexer.OP_MUL: node = new AstNode.MulNode(); break;
                case ExprLexer.OP_DIV: node = new AstNode.DivNode(); break;
                case ExprLexer.OP_POW: node = new AstNode.PowNode(); break;
                case ExprLexer.OP_EQ: node = new AstNode.EqNode(); break;
                case ExprLexer.OP_NE: node = new AstNode.NeNode(); break;
                case ExprLexer.OP_LS: node = new AstNode.LsNode(); break;
                case ExprLexer.OP_GR: node = new AstNode.GrNode(); break;
                case ExprLexer.OP_GE: node = new AstNode.GeNode(); break;
                case ExprLexer.OP_LE: node = new AstNode.LeNode(); break;
                default: throw new ArgumentException("Not supported!");
            }

            node.Left = Visit(context.left) as AstNode.ExprNode;
            node.Right = Visit(context.right) as AstNode.ExprNode;
            return node;
        }

        public override AstNode VisitFuncExpr(ExprParser.FuncExprContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Error at func expr");
            }

            AstNode.FuncNode node = new AstNode.FuncNode();
            //{
            //    FuncName = context.func.Text,
            //    Arguments = Visit(context.args) as AstNode.FuncArgs,
            //};

            node.FuncName = context.func.Text;
            if (context.args == null) throw new ArgumentException("No arguments provided!");
            node.Arguments = Visit(context.args) as AstNode.FuncArgs;

            return node;
        }

        public override AstNode VisitFuncArgs(ExprParser.FuncArgsContext context)
        {
            AstNode.FuncArgs node = new AstNode.FuncArgs();
            foreach (var expr in context.expr())
            {
                node.Argumets.Add(Visit(expr) as AstNode.ExprNode);
            }
            return node;
        }
    }
}