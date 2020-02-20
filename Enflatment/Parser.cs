using System;
using System.Collections.Generic;

namespace Enflatment
{
    /// <summary>
    /// Provides tools for syntax analysis
    /// </summary>
    internal class Parser
    {
        private readonly Lexer _lexer;
        private Token _peek;

        public Parser(Lexer lexer)
        {
            _lexer = lexer;
            _peek = _lexer.Scan();
        }

        private protected virtual Token Peek() => _peek;

        private protected virtual bool CheckType(TokenType type)
        {
            return Peek().Type == type;
        }

        private protected virtual bool MatchType(TokenType type)
        {
            bool b = Peek().Type == type;
            _peek = _lexer.Scan();
            return b;
        }

        private protected virtual void Error() 
            => throw new ArgumentException($"Unexpected token got: `{Peek()}` at [{Peek().Line}:{Peek().Col}]");

        public ArrayItem ParseArrayItem()
        {
            var arrayItem = ArrItem();
            if (_peek.Type != TokenType.EOF)
                Error();
            return arrayItem;
        }

        /*
         * ArrItem ::= [ItemList] | []
         * ItemList ::= SingleItem OptList
         * OptList ::= , ItemList | epsilon
         * SingleItem ::= Num | ArrItem
         */

        private ArrayItem ArrItem()
        {
            ArrayItem arrayItem = new ArrayItem();

            if (CheckType(TokenType.OpenBracket))
            {
                MatchType(TokenType.OpenBracket);
                if (CheckType(TokenType.CloseBracket))
                {
                    MatchType(TokenType.CloseBracket);
                    return arrayItem;
                }
                arrayItem.Items.AddRange(ItemList());
                if (!CheckType(TokenType.CloseBracket))
                    Error();
                MatchType(TokenType.CloseBracket);
            }
            else Error();

            return arrayItem;
        }

        private List<Item> ItemList()
        {
            List<Item> items = new List<Item>();

            items.Add(SingleItem());
            items.AddRange(OptParams());

            return items;
        }

        private List<Item> OptParams()
        {
            List<Item> items = new List<Item>();
            while (CheckType(TokenType.Coma))
            {
                MatchType(TokenType.Coma);
                items.AddRange(ItemList());
            }
            return items;
        }

        private Item SingleItem()
        {
            if (CheckType(TokenType.Num))
            {
                int n = ((NumToken) Peek()).Value;
                MatchType(TokenType.Num);
                return new NumItem(n);
            }

            return ArrItem();
        }
    }
}