namespace Partiality
{
    /// <summary>
    /// Enumeration of common lexeme's types
    /// Used in Lexer
    /// </summary>
    internal enum TokenType
    {
        EOF,
        Num,
        Id,
        RParen,
        LParen,
        Coma,
        Op1,
        Plus,
        Minus,
        Op2,
        Div,
        Mul,
        Op3,
        Pow,
        Keyword,
        If,
        Defun,
    }
}