using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Partiality
{
    internal class ListExprLexer : Lexer
    {
        private readonly HashSet<char> _literalFollow = new HashSet<char>()
        {
            '*', '/', '+', '-', ')', '(', ','
        };

        private readonly Dictionary<string, TokenType> _keyWords = new Dictionary<string, TokenType>()
        {
            {"if", TokenType.If},
            {"defun", TokenType.Defun},
        };

        /*
         * S ::= [ S | NUM S | ] S | , S | [+-/*] S | ID S | EOF
         * `**` stays for powerof operator!
         */
        public override Token Scan()
        {
            while (char.IsWhiteSpace(Peek()))
                Match(Peek());
            if (EOF)
                return new Token { Type = TokenType.EOF, Col = _pos, Line = _line };
            switch (Peek())
            {
                // Resolving arithmetic operations
                case '+': Match('+'); return new Token { Type = TokenType.Plus, Col = _pos - 1, Line = _line };
                case '-': Match('-'); return new Token { Type = TokenType.Minus, Col = _pos - 1, Line = _line };
                case '*':
                    Match('*');
                    if (Peek() == '*') // Checking for `**` operator
                    {
                        Match('*');
                        return new Token { Type = TokenType.Pow, Col = _pos - 2, Line = _line };
                    }
                    return new Token { Type = TokenType.Mul };
                case '/': Match('/'); return new Token { Type = TokenType.Div, Col = _pos - 1, Line = _line };
                // Resolving Parentheses
                case '(': Match('('); return new Token { Type = TokenType.LParen, Col = _pos - 1, Line = _line };
                case ')': Match(')'); return new Token { Type = TokenType.RParen, Col = _pos - 1, Line = _line };
                // Resolving separator
                case ',': Match(','); return new Token() { Type = TokenType.Coma, Col = _pos - 1, Line = _line };
                // Then, we could face either digit or unwanted character
                default:
                    if (char.IsDigit(Peek())) // Try to get numeric literal
                        return ReadNumber();
                    else if (char.IsLetter(Peek()))
                        return ReadId();
                    Error(); // Nothing matches 
                    break;
            }

            return null; // Redundant
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Identifyer token</returns>
        private Token ReadId()
        {
            
            StringBuilder sb = new StringBuilder();
            // Assuming that this method is always called from Scan(),
            // I don't check the first character to be letter
            while (char.IsLetterOrDigit(Peek()))
            {
                sb.Append(Peek().ToString());
                Match(Peek());
            }

            if (!ValidLiteralFollow(Peek()))
                Error();
            if (_keyWords.ContainsKey(sb.ToString()))
            {
                return new Token() {Type = _keyWords[sb.ToString()], Col = _pos, Line = _line};
            }

            IdToken idToken = new IdToken { Col = _pos, Line = _line };
            idToken.Literal = sb.ToString();
            return idToken;
        }

        private NumToken ReadNumber()
        {
            NumToken numToken = new NumToken { Col = _pos, Line = _line };
            StringBuilder sb = new StringBuilder();
            while (!EOF && char.IsDigit(Peek()))
            {
                sb.Append(Peek().ToString());
                Match(Peek());
            }

            if (!ValidLiteralFollow(Peek()))
                Error();

            numToken.Literal = sb.ToString();
            return numToken;
        }

        private bool ValidLiteralFollow(char c) => EOF || _literalFollow.Contains(c) || char.IsWhiteSpace(c);

        public ListExprLexer(StringReader sr) : base(sr) { }
    }
}