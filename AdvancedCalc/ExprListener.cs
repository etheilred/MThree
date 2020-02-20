//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Expr.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="ExprParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IExprListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ExprParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompileUnit([NotNull] ExprParser.CompileUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ExprParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompileUnit([NotNull] ExprParser.CompileUnitContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>p0Expr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterP0Expr([NotNull] ExprParser.P0ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>p0Expr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitP0Expr([NotNull] ExprParser.P0ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>purenExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPurenExpr([NotNull] ExprParser.PurenExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>purenExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPurenExpr([NotNull] ExprParser.PurenExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>funcExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncExpr([NotNull] ExprParser.FuncExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>funcExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncExpr([NotNull] ExprParser.FuncExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>negExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNegExpr([NotNull] ExprParser.NegExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>negExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNegExpr([NotNull] ExprParser.NegExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>numExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumExpr([NotNull] ExprParser.NumExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>numExpr</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumExpr([NotNull] ExprParser.NumExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ExprParser.funcArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncArgs([NotNull] ExprParser.FuncArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ExprParser.funcArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncArgs([NotNull] ExprParser.FuncArgsContext context);
}
