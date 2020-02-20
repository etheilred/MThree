using System;

namespace Partiality
{
    /// <summary>
    /// Provides basic functionality for Parser implementation
    /// </summary>
    internal abstract class Parser
    {
        private protected readonly Lexer _lexer;
        private Token _peek;
        public Parser(Lexer lexer)
        {
            _lexer = lexer;
            _peek = _lexer.Scan();
        }

        private bool EOF => _lexer.EOF;

        public abstract AstNode Parse();

        public virtual void Error()
            => throw new ArgumentException($"Unexpected token `{_peek}` at [{_peek.Line}:{_peek.Col}]");

        public virtual Token Peek() => _peek;

        public virtual bool CheckType(TokenType type) => _peek.Type == type;

        public virtual void MatchType(TokenType type)
        {
            if (_peek.Type != type)
                Error();
            _peek = _lexer.Scan();
        }
    }
}