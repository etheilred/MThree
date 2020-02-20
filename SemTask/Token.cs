namespace SemTask
{
    internal class Token
    {
        public int Col { get; set; }
        public int Line { get; set; }
        public TokenType Type { get; set; }
        public override string ToString()
        {
            return $"{Type}";
        }
    }

    internal abstract class VariableToken : Token
    {
        public abstract string Literal { get; set; }
    }

    internal class NumToken : VariableToken
    {
        public override string Literal { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" : {Literal}";
        }

        public NumToken()
        {
            Type = TokenType.Num;
        }
    }

    internal class IdToken : VariableToken
    {
        public override string Literal { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" : {Literal}";
        }

        public IdToken()
        {
            Type = TokenType.Id;
        }
    }
}