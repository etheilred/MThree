using System;
using System.IO;

namespace Partiality
{
    /// <summary>
    /// Provides basic functionality useful for lexical analysis
    /// </summary>
    internal class Lexer : ILexer
    {
        private readonly StringReader _stream;
        public bool EOF => _stream.Peek() == -1;
        private protected int _pos;
        private protected int _line;

        public Lexer(StringReader stream)
        {
            _stream = stream;
            _pos = 1;
            _line = 1;
        }

        public virtual Token Scan()
        {
            throw new NotImplementedException();
        }

        private protected virtual char Peek() => (char)_stream.Peek();

        private protected virtual void Error() 
        => throw new ArgumentException($"Unexpected `{Peek()}` got at {_pos}");

        private protected virtual bool Match(char c)
        {
            bool t = _stream.Peek() == c;
            _stream.Read();
            if (Peek() == '\n')
            {
                ++_line;
                _pos = 0;
            }
            ++_pos;
            return t;
        }
    }
}