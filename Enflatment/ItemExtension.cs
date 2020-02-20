using System;
using System.Collections.Generic;

namespace Enflatment
{
    internal static class ItemExtension
    {
        public static void ReadArrayItem(this ArrayItem item, string source, bool clearPrevious = false)
        {
            if (clearPrevious)
                item.Items.Clear();

            int pos = 0;
            item.Items.AddRange(FromString(source, ref pos).Items);
        }

        /*
         * S -> [S] | ParamList
         * ParamList -> [S] OptParams | NUM | NUM OptParams
         * OptParams -> , ParamList | eps
         * NUM -> int
         */
        private static ArrayItem FromString(string str, ref int pos)
        {
            ArrayItem arrayItem = new ArrayItem();

            if (str[pos] == '[')
            {
                ++pos;
                while (pos < str.Length && str[pos] != ']')
                {
                    if (str[pos] == '[')
                    {
                        arrayItem.Items.Add(FromString(str, ref pos));
                        if (pos >= str.Length)
                            throw new ArgumentException($"Missing closing parenthesis at pos {str.Length - 1}");
                        if (str[pos] != ']')
                            throw new ArgumentException($"Missing closing parenthesis at pos {pos}");
                        ++pos;
                        if (pos < str.Length && str[pos] == ',')
                            ++pos;
                    }
                    else if (char.IsDigit(str[pos]))
                    {
                        Console.WriteLine("Processing number");
                        NumItem tmp = new NumItem();
                        while (pos < str.Length && char.IsDigit(str[pos]))
                        {
                            tmp.Value *= 10;
                            tmp.Value += int.Parse(str[pos].ToString());
                            ++pos;
                        }
                        arrayItem.Items.Add(tmp);

                        if (pos < str.Length && str[pos] == ',')
                            ++pos;
                    }
                    else throw new ArgumentException($"Unexpected `{str[pos]}` got at pos {pos}");
                }
                if (pos >= str.Length && str[str.Length - 1] != ']')
                    throw new ArgumentException($"Missing closing parenthesis at pos {str.Length - 1}");
            }
            else throw new ArgumentException($"Unexpected `{str[pos]}` got at pos {pos}");

            return arrayItem;
        }

        /*
         * List ::= [ListElements] | []
         * ListElements ::= ListElement OptList
         * OptList ::= , ListElements
         * ListElement ::= List | Number
         */

        public static ArrayItem ListNTerm(string s, ref int pos)
        {
            ArrayItem arrayItem = new ArrayItem();
            Console.WriteLine("ListNTerm");

            if (s[pos] == '[')
            {
                ++pos;
                if (s[pos] == ']')
                    return arrayItem;
                arrayItem.Items.AddRange(ListElementsNTerm(s, ref pos));
                if (s[pos] == ']')
                    ++pos;
                else throw new ArgumentException($"[ListNTerm(inner)] Unexpected `{s[pos]}` got at {pos}");
            }
            else throw new ArgumentException($"[ListNTerm] Unexpected `{s[pos]}` got at {pos}");

            return arrayItem;
        }

        public static List<Item> ListElementsNTerm(string s, ref int pos)
        {
            if (pos >= s.Length)
                throw new ArgumentException($"Not enough symbols in input string");
            List<Item> items = new List<Item>();
            Console.WriteLine("ListElementsNTerm");

            if (s[pos] == '[' || char.IsDigit(s[pos]))
            {
                items.Add(ListElementNTerm(s, ref pos));
            }
            else throw new ArgumentException($"[ListElementsNTerm, 1] Unexpected `{s[pos]}` got at {pos}");
            if (pos >= s.Length)
                throw new ArgumentException($"Not enough symbols in input string");
            if (s[pos] == ',')
            {
                items.AddRange(OptListNTerm(s, ref pos));
            }
            else if (s[pos] == ']') { }
            else throw new ArgumentException($"[ListElementsNTerm, 2] Unexpected `{s[pos]}` got at {pos}");

            return items;
        }

        public static List<Item> OptListNTerm(string s, ref int pos)
        {
            List<Item> items = new List<Item>();
            Console.WriteLine("OptListNTerm");

            while (pos < s.Length && s[pos] == ',')
            {
                ++pos;
                items.AddRange(ListElementsNTerm(s, ref pos));
            }

            return items;
        }

        public static Item ListElementNTerm(string s, ref int pos)
        {
            Item item = new Item();
            Console.WriteLine("ListElementNTerm");

            if (s[pos] == '[')
            {
                item = ListNTerm(s, ref pos);
            }
            else if (char.IsDigit(s[pos]))
            {
                Console.WriteLine("Number encountered");
                item = new NumItem();
                while (pos < s.Length && char.IsDigit(s[pos]))
                {
                    ((NumItem) item).Value *= 10;
                    ((NumItem) item).Value += int.Parse(s[pos].ToString());
                    ++pos;
                }
            }

            return item;
        }
    }
}