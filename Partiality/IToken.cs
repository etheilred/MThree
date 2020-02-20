namespace Partiality
{
    /// <summary>
    /// Declares that all Token types must contain `TokenType Type {get;set;}` property
    /// </summary>
    internal interface IToken
    {
        TokenType Type { get; set; }
    }
}