using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace FormuleParser
{
    internal class BuildAstVisitor : ExprBaseVisitor<ExprNode>
    {
        public override ExprNode VisitCompileUnit(ExprParser.CompileUnitContext context)
        {
            return Visit(context.expr());
        }

        public override ExprNode VisitNumberExpr(ExprParser.NumberExprContext context)
        {
            return new NumberNode()
            {
                Value = double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)
            };
        }

        public override ExprNode VisitParensExpr(ExprParser.ParensExprContext context)
        {
            return Visit(context.expr());
        }

        public override ExprNode VisitInfixExpr(ExprParser.InfixExprContext context)
        {
            InfixNode node;

            switch (context.op.Type)
            {
                case ExprLexer.OP_ADD: node = new AddNode(); break;
                case ExprLexer.OP_SUB: node = new SubNode(); break;
                case ExprLexer.OP_DIV: node = new DivNode(); break;
                case ExprLexer.OP_MUL: node = new MulNode(); break;
                case ExprLexer.OP_POW: node = new PowNode(); break;
                default: throw new NotSupportedException($"Operation type {context.op.Type} is not supported");
            }

            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        public override ExprNode VisitUnaryExpr(ExprParser.UnaryExprContext context)
        {
            switch (context.op.Type)
            {
                case ExprLexer.OP_ADD: return Visit(context.expr());
                case ExprLexer.OP_SUB: return new NegNode() { InnerNode = Visit(context.expr()) };
                default: throw new NotSupportedException($"Unary operator {context.op} is not supported");
            }
        }

        public override ExprNode VisitFuncExpr(ExprParser.FuncExprContext context)
        {
            var funcName = context.func.Text;
            var func = typeof(Math)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.ReturnType == typeof(double))
                .Where(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(new[] { typeof(double) }))
                .FirstOrDefault(m => m.Name.Equals(funcName, StringComparison.OrdinalIgnoreCase));
            if (func == null)
                throw new NotSupportedException($"Function {funcName} is not supported!");
            return new FuncNode()
            {
                Function = (Func<double, double>)func.CreateDelegate(typeof(Func<double, double>)),
                Argument = Visit(context.expr()),
                FName = funcName,
            };
        }
    }
}