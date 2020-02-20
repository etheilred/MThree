using System;
using System.IO;
using System.Text;

namespace SemTask
{
    internal class Lexer
    {
        private readonly StringReader _reader;
        private int Col = 1;
        private int Line = 1;

        public bool Eof => _reader.Peek() == -1;

        public Lexer(StringReader reader)
        {
            _reader = reader;
        }

        private void Error() => throw new ArgumentException($"Unexpected `{Peek()}` at [{Line}:{Col}]");

        private void Error(char c)
            => throw new ArgumentException($"Unexpected `{c}` at [{Line}:{Col}]");

        public char Peek() => (char)_reader.Peek();

        public void Match(char c)
        {
            if (c != Peek())
                Error();

            if ((char)_reader.Read() == '\n')
            {
                ++Line;
                Col = 1;
            }
            else ++Col;
        }

        public Token Scan()
        {
            while (char.IsWhiteSpace(Peek()))
                Match(Peek());

            if (Eof)
                return new Token { Type = TokenType.EOF, Col = Col, Line = Line };

            switch (Peek())
            {
                case '(': Match('('); return new Token { Type = TokenType.OpenParen, Col = Col, Line = Line };
                case ')': Match(')'); return new Token { Type = TokenType.CloseParen, Col = Col, Line = Line };
                case '\'': Match('\''); return new Token { Type = TokenType.Apostrophe, Col = Col, Line = Line };
            }

            if (char.IsDigit(Peek()) || Peek() == '-')
                return ReadNum();

            if (char.IsLetter(Peek()))
                return ReadId();

            Error();
            return null;
        }

        private Token ReadNum()
        {
            NumToken num = new NumToken { Col = Col, Line = Line };
            StringBuilder sb = new StringBuilder();
            if (Peek() == '-')
            { 
                sb.Append('-');
                Match(Peek());
                if (!char.IsDigit(Peek()))
                {
                    --Col;
                    Error('-');
                }
            }
            
            while (char.IsDigit(Peek()))
            {
                sb.Append(Peek());
                Match(Peek());
            }

            num.Literal = sb.ToString();
            return num;
        }

        private Token ReadId()
        {
            IdToken id = new IdToken { Col = Col, Line = Line };
            StringBuilder sb = new StringBuilder();
            while (char.IsLetterOrDigit(Peek()))
            {
                sb.Append(Peek());
                Match(Peek());
            }

            id.Literal = sb.ToString();
            return id;
        }
    }
}