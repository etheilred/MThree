using System;

namespace SemTask
{
    /*
     * E ::= atom | ' E | ( E Es )
     * Es ::= E Es | eps
     */

    internal class Parser
    {
        private readonly Lexer _lexer;
        private Token Peek;
        public bool Eof => Peek.Type == TokenType.EOF;

        public Parser(Lexer lexer)
        {
            _lexer = lexer ?? throw new ArgumentNullException($"Lexer is null");
            Peek = _lexer.Scan() ?? throw new ArgumentNullException($"First token was null");
        }

        private void Error()
            => throw new ArgumentException($"Unexpected token {Peek} at [{Peek.Line}:{Peek.Col}]");

        private void MatchType(TokenType type)
        {
            if (Peek.Type != type)
                Error();
            Peek = _lexer.Scan();
        }

        private bool CheckType(TokenType type) => type == Peek.Type;

        public RootNode Parse()
        {
            RootNode ast = new RootNode { Root = E() };
            if (!Eof)
                Error();
            return ast;
        }

        private AstNode E()
        {
            switch (Peek.Type)
            {
                case TokenType.Id:
                    try
                    {
                        return new IdNode { Token = (IdToken)Peek };
                    }
                    finally
                    {
                        MatchType(Peek.Type);
                    }
                case TokenType.Num:
                    try
                    {
                        return new NumNode { Token = (NumToken)Peek };
                    }
                    finally
                    {
                        MatchType(Peek.Type);
                    }
                case TokenType.Apostrophe:
                    MatchType(Peek.Type);
                    return new QuotedNode { Quoted = E() };
                case TokenType.OpenParen:
                    MatchType(Peek.Type);
                    ListNode lst = new ListNode { Head = E(), Tail = Es() };
                    MatchType(TokenType.CloseParen);
                    return lst;
                default:
                    Error();
                    break;
            }

            return null;
        }

        private ListNode Es()
        {
            switch (Peek.Type)
            {
                case TokenType.Id:
                case TokenType.Num:
                case TokenType.Apostrophe:
                case TokenType.OpenParen:
                    return new ListNode { Head = E(), Tail = Es() };
                case TokenType.CloseParen:
                    return null;
                default:
                    Error();
                    break;
            }

            return null;
        }
    }
}