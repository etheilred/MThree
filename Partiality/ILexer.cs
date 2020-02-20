namespace Partiality
{
    /// <summary>
    /// Declares that all Lexers must contain public `Token Scan()` method
    /// </summary>
    internal interface ILexer
    {
        Token Scan();
    }
}