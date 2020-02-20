using System;

namespace Enflatment
{
    /// <summary>
    /// Provides tools for lexical analysis
    /// </summary>
    internal class Lexer
    {
        private readonly string _input;
        private int _current = 0;
        private int _col;
        private int _line;

        private protected bool EOF => _current >= _input.Length;

        public Lexer(string input)
        {
            _input = input;
            _col = 0;
            _line = 1;
        }

        private protected virtual char Peek()
        {
            if (EOF) return ' ';
            return _input[_current];
        }

        private protected virtual bool Match(char c)
        {
            if (EOF)
                return false;

            if (Peek() == c)
            {
                if (c.ToString() == Environment.NewLine)
                {
                    ++_line;
                    _col = 0;
                }
                else ++_col;
                ++_current;
                return true;
            }

            return false;
        }

        public virtual Token Scan()
        {
            while (char.IsWhiteSpace(Peek()) && Match(Peek())) { }
            if (EOF)
                return new Token { Type = TokenType.EOF, Line = _line, Col = _col};

            if (Peek() == '[')
            {
                Match('[');
                return new Token { Type = TokenType.OpenBracket, Line = _line, Col = _col };
            }

            if (Peek() == ']')
            {
                Match(']');
                return new Token { Type = TokenType.CloseBracket, Line = _line, Col = _col };
            }

            if (Peek() == ',')
            {
                Match(',');
                return new Token { Type = TokenType.Coma, Line = _line, Col = _col };
            }

            if (char.IsDigit(Peek()))
            {
                NumToken num = new NumToken { Line = _line, Col = _col };
                while (char.IsDigit(Peek()))
                {
                    num.Value *= 10;
                    num.Value += int.Parse(Peek().ToString());
                    Match(Peek());
                }

                return num;
            }

            throw new ArgumentException($"Unexpected `{Peek()}` got at pos {_current}");
        }
    }

    internal class Token
    {
        public int Line { get; set; }
        public int Col { get; set; }
        public TokenType Type { get; set; }
        public override string ToString()
        {
            return $"{Type}";
        }
    }

    internal class NumToken : Token
    {
        public int Value { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" : {Value}";
        }

        public NumToken()
        {
            Type = TokenType.Num;
        }
    }

    internal enum TokenType
    {
        Id, Num, OpenBracket, CloseBracket, Coma, EOF
    }
}