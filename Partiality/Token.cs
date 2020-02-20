using System;

namespace Partiality
{
    /// <summary>
    /// Describes Token type with following structure:
    /// Type of TokenType - to store token's type
    /// Col of int - to store token's position in line
    /// Line of int - to store the line where the token was encountered
    /// </summary>
    /// <overrides>ToString()</overrides>
    internal class Token : IToken
    {
        public TokenType Type { get; set; }
        public int Col { get; set; }
        public int Line { get; set; }
        public override string ToString()
        {
            return $"{Type}";
        }
    }

    /// <summary>
    /// Describes Token for Numeric constant, derived from Token type,
    /// in addition, has `string Literal {get;set;}` property for storing constant's literal
    /// </summary>
    /// <overrides>ToString()</overrides>
    internal class NumToken : Token
    {
        public string Literal { get; set; }

        public NumToken()
        {
            Type = TokenType.Num;
        }

        public override string ToString()
        {
            return base.ToString() + $" : {Literal}";
        }
    }

    /// <summary>
    /// Describes Token for identifiers 
    /// </summary>
    internal class IdToken : Token
    {
        public string Literal { get; set; }

        public IdToken()
        {
            Type = TokenType.Id;
        }

        public override string ToString()
        {
            return base.ToString() + $" : {Literal}";
        }
    }
}