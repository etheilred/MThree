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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class ExprParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, OP_ADD=3, OP_SUB=4, OP_MUL=5, OP_DIV=6, OP_POW=7, NUM=8, 
		ID=9, WS=10;
	public const int
		RULE_compileUnit = 0, RULE_expr = 1;
	public static readonly string[] ruleNames = {
		"compileUnit", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'+'", "'-'", "'*'", "'/'", "'^'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "OP_ADD", "OP_SUB", "OP_MUL", "OP_DIV", "OP_POW", "NUM", 
		"ID", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Expr.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ExprParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public ExprParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public ExprParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class CompileUnitContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(ExprParser.Eof, 0); }
		public CompileUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compileUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterCompileUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitCompileUnit(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompileUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompileUnitContext compileUnit() {
		CompileUnitContext _localctx = new CompileUnitContext(Context, State);
		EnterRule(_localctx, 0, RULE_compileUnit);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 4; expr(0);
			State = 5; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class InfixExprContext : ExprContext {
		public ExprContext left;
		public IToken op;
		public ExprContext right;
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public ITerminalNode OP_POW() { return GetToken(ExprParser.OP_POW, 0); }
		public ITerminalNode OP_MUL() { return GetToken(ExprParser.OP_MUL, 0); }
		public ITerminalNode OP_DIV() { return GetToken(ExprParser.OP_DIV, 0); }
		public ITerminalNode OP_ADD() { return GetToken(ExprParser.OP_ADD, 0); }
		public ITerminalNode OP_SUB() { return GetToken(ExprParser.OP_SUB, 0); }
		public InfixExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterInfixExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitInfixExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInfixExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryExprContext : ExprContext {
		public IToken op;
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode OP_ADD() { return GetToken(ExprParser.OP_ADD, 0); }
		public ITerminalNode OP_SUB() { return GetToken(ExprParser.OP_SUB, 0); }
		public UnaryExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterUnaryExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitUnaryExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class FuncExprContext : ExprContext {
		public IToken func;
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode ID() { return GetToken(ExprParser.ID, 0); }
		public FuncExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterFuncExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitFuncExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumberExprContext : ExprContext {
		public IToken value;
		public ITerminalNode NUM() { return GetToken(ExprParser.NUM, 0); }
		public NumberExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterNumberExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitNumberExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumberExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParensExprContext : ExprContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ParensExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.EnterParensExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IExprListener typedListener = listener as IExprListener;
			if (typedListener != null) typedListener.ExitParensExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IExprVisitor<TResult> typedVisitor = visitor as IExprVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParensExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 20;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__0:
				{
				_localctx = new ParensExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 8; Match(T__0);
				State = 9; expr(0);
				State = 10; Match(T__1);
				}
				break;
			case OP_ADD:
			case OP_SUB:
				{
				_localctx = new UnaryExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 12;
				((UnaryExprContext)_localctx).op = TokenStream.LT(1);
				_la = TokenStream.LA(1);
				if ( !(_la==OP_ADD || _la==OP_SUB) ) {
					((UnaryExprContext)_localctx).op = ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 13; expr(6);
				}
				break;
			case ID:
				{
				_localctx = new FuncExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 14; ((FuncExprContext)_localctx).func = Match(ID);
				State = 15; Match(T__0);
				State = 16; expr(0);
				State = 17; Match(T__1);
				}
				break;
			case NUM:
				{
				_localctx = new NumberExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 19; ((NumberExprContext)_localctx).value = Match(NUM);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 33;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 31;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
					case 1:
						{
						_localctx = new InfixExprContext(new ExprContext(_parentctx, _parentState));
						((InfixExprContext)_localctx).left = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 22;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 23; ((InfixExprContext)_localctx).op = Match(OP_POW);
						State = 24; ((InfixExprContext)_localctx).right = expr(5);
						}
						break;
					case 2:
						{
						_localctx = new InfixExprContext(new ExprContext(_parentctx, _parentState));
						((InfixExprContext)_localctx).left = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 25;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 26;
						((InfixExprContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==OP_MUL || _la==OP_DIV) ) {
							((InfixExprContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 27; ((InfixExprContext)_localctx).right = expr(5);
						}
						break;
					case 3:
						{
						_localctx = new InfixExprContext(new ExprContext(_parentctx, _parentState));
						((InfixExprContext)_localctx).left = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 28;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 29;
						((InfixExprContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==OP_ADD || _la==OP_SUB) ) {
							((InfixExprContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 30; ((InfixExprContext)_localctx).right = expr(4);
						}
						break;
					}
					} 
				}
				State = 35;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 5);
		case 1: return Precpred(Context, 4);
		case 2: return Precpred(Context, 3);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\f', '\'', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x5', '\x3', '\x17', '\n', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\a', '\x3', '\"', '\n', '\x3', 
		'\f', '\x3', '\xE', '\x3', '%', '\v', '\x3', '\x3', '\x3', '\x2', '\x3', 
		'\x4', '\x4', '\x2', '\x4', '\x2', '\x4', '\x3', '\x2', '\x5', '\x6', 
		'\x3', '\x2', '\a', '\b', '\x2', '*', '\x2', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '\x4', '\x16', '\x3', '\x2', '\x2', '\x2', '\x6', '\a', '\x5', 
		'\x4', '\x3', '\x2', '\a', '\b', '\a', '\x2', '\x2', '\x3', '\b', '\x3', 
		'\x3', '\x2', '\x2', '\x2', '\t', '\n', '\b', '\x3', '\x1', '\x2', '\n', 
		'\v', '\a', '\x3', '\x2', '\x2', '\v', '\f', '\x5', '\x4', '\x3', '\x2', 
		'\f', '\r', '\a', '\x4', '\x2', '\x2', '\r', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\xE', '\xF', '\t', '\x2', '\x2', '\x2', '\xF', '\x17', '\x5', 
		'\x4', '\x3', '\b', '\x10', '\x11', '\a', '\v', '\x2', '\x2', '\x11', 
		'\x12', '\a', '\x3', '\x2', '\x2', '\x12', '\x13', '\x5', '\x4', '\x3', 
		'\x2', '\x13', '\x14', '\a', '\x4', '\x2', '\x2', '\x14', '\x17', '\x3', 
		'\x2', '\x2', '\x2', '\x15', '\x17', '\a', '\n', '\x2', '\x2', '\x16', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x16', '\xE', '\x3', '\x2', '\x2', 
		'\x2', '\x16', '\x10', '\x3', '\x2', '\x2', '\x2', '\x16', '\x15', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '#', '\x3', '\x2', '\x2', '\x2', '\x18', 
		'\x19', '\f', '\a', '\x2', '\x2', '\x19', '\x1A', '\a', '\t', '\x2', '\x2', 
		'\x1A', '\"', '\x5', '\x4', '\x3', '\a', '\x1B', '\x1C', '\f', '\x6', 
		'\x2', '\x2', '\x1C', '\x1D', '\t', '\x3', '\x2', '\x2', '\x1D', '\"', 
		'\x5', '\x4', '\x3', '\a', '\x1E', '\x1F', '\f', '\x5', '\x2', '\x2', 
		'\x1F', ' ', '\t', '\x2', '\x2', '\x2', ' ', '\"', '\x5', '\x4', '\x3', 
		'\x6', '!', '\x18', '\x3', '\x2', '\x2', '\x2', '!', '\x1B', '\x3', '\x2', 
		'\x2', '\x2', '!', '\x1E', '\x3', '\x2', '\x2', '\x2', '\"', '%', '\x3', 
		'\x2', '\x2', '\x2', '#', '!', '\x3', '\x2', '\x2', '\x2', '#', '$', '\x3', 
		'\x2', '\x2', '\x2', '$', '\x5', '\x3', '\x2', '\x2', '\x2', '%', '#', 
		'\x3', '\x2', '\x2', '\x2', '\x5', '\x16', '!', '#',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
