using System;
using System.IO;

namespace RecDescend
{
    public class Scanner
    {
        private Stream _inputStream;
        private char _peek = ' ';

        private bool EndOfStream
        {
            get => _inputStream.Position >= _inputStream.Length;
        }

        public Scanner(Stream inputStream)
        {
            _inputStream = inputStream;
        }

        public char ReadTest()
        {
            return (char)_inputStream.ReadByte();
        }

        public virtual Token Scan()
        {
            if (EndOfStream)
            {
                return new Token() { Type = TokType.EOF };
            }

            while (_peek == ' ')
            {
                _peek = (char)_inputStream.ReadByte();
            }

            if (char.IsDigit(_peek))
            {
                string numLiteral = "";
                while (char.IsDigit(_peek))
                {
                    numLiteral += _peek;
                    if (EndOfStream)
                        break;
                    _peek = (char) _inputStream.ReadByte();
                }
                return new NumToken() { Type = TokType.Num, Value = int.Parse(numLiteral) };
            }

            if (char.IsLetter(_peek))
            {
                string idLiteral = "";
                while (char.IsLetterOrDigit(_peek))
                {
                    idLiteral += _peek;
                    if (EndOfStream) 
                        break;
                    _peek = (char) _inputStream.ReadByte();
                }
                return new IdToken(){Type = TokType.Id, Literal = idLiteral};
            }

            Console.WriteLine((byte)_peek);
            Console.ReadKey(true);
            return new IdToken() { Type = TokType.Id, Literal = _peek.ToString() };
        }
    }

    public class Token
    {
        public TokType Type { get; set; }
        public override string ToString()
        {
            return $"Type : {Type}";
        }
    }

    public class NumToken : Token
    {
        public double Value { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"; Value : {Value}";
        }
    }

    public class IdToken : Token
    {
        public string Literal { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"; Literal : {Literal}";
        }
    }

    public enum TokType
    {
        Num, Id, Plus, Minus, OpenPuren, ClosePuren, EOF
    }
}