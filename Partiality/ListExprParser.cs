using System;

namespace Partiality
{
    /*
     * SExpr ::= () | (Atoms) | ([Op Keyword] OptAtoms)
     * Atoms ::= Atom OptAtoms
     * OptAtoms ::= Atoms | , Atoms | eps     // (A B) and (A, B) are both legal
     * Atom ::= NUM | ID | OP | SExpr
     * Op ::= [+-/*]
     * Keyword ::= if | defun
     *
     * derivation of `(a b)`:
     * SExpr -> (Atoms) -> (Atom OptAtoms) -> (ID Atoms) -> (a Atom OptAtoms) -> (a b)
     */

    /// <summary>
    /// Provides parser of list expressions
    /// </summary>
    internal class ListExprParser : Parser
    {
        public ListExprParser(Lexer lexer) : base(lexer) { }

        public override AstNode Parse()
        {
            AstNode ast = SExpr();
            if (Peek().Type != TokenType.EOF)
                Error();
            return ast;
        }

        /// <summary>
        /// Initial non-terminal
        /// </summary>
        /// <returns></returns>
        private SExprNode SExpr()
        {
            MatchType(TokenType.LParen);
            if (CheckType(TokenType.RParen))
            {
                MatchType(TokenType.RParen);
                return new NilNode();
            }
            var t = Atoms();
            MatchType(TokenType.RParen);
            return t;
        }

        /// <summary>
        /// Parses lists of atoms
        /// </summary>
        /// <returns></returns>
        private SExprNode Atoms()
        {
            SExprNode exprNode = new SExprNode();
            exprNode.Head = Atom();
            exprNode.Tail = OptAtoms();
            return exprNode;
        }

        /// <summary>
        /// Parses single atom
        /// </summary>
        /// <returns></returns>
        private AstNode Atom()
        {
            switch (Peek().Type)
            {
                case TokenType.Num:
                    var numToken = Peek() as NumToken;
                    MatchType(TokenType.Num);
                    if (numToken == null)
                        throw new ArgumentException($"Cannot cast `{Peek()}` to number");
                    return new NumNode { Literal = numToken.Literal };
                case TokenType.Id:
                    var idToken = Peek() as IdToken;
                    MatchType(TokenType.Id);
                    if (idToken == null)
                        throw new ArgumentException($"Cannot cast `{Peek()}` to identifier");
                    return new IdNode { Literal = idToken.Literal };
                case TokenType.LParen:
                    return SExpr();
                default:
                    if (Peek().Type > TokenType.Op1)
                    {
                        var t = Peek().Type;
                        MatchType(Peek().Type);
                        return new IdNode {Literal = $"{t}"};
                    }
                    Error();
                    break;
            }
            return null;
        }

        /// <summary>
        /// Parses, if present, optional list of atoms
        /// </summary>
        /// <returns></returns>
        private AstNode OptAtoms()
        {
            switch (Peek().Type)
            {
                case TokenType.Coma:
                    MatchType(TokenType.Coma);
                    return Atoms();
                case TokenType.Id:
                case TokenType.Num:
                case TokenType.LParen:
                    return Atoms();
                case TokenType.RParen:
                    break;
                default:
                    Error();
                    break;
            }
            return null;
        }
    }
}