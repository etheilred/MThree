using System.Linq;

namespace RecDescend
{
    class Lexer
    {
        /*
         * S ::= numA | if S | else S | then S | [+-/*=><!()]S
         * A ::= if S | else S | then S | [+-/*=><!()]S | eps;
         */
        private string _inp;
        private int _current;
        private bool EOF => _current >= _inp.Length;

        private char CurrentChar
        {
            get
            {
                // Console.Write(_inp[_current]);
                return _inp[_current];
            }
        }

        private char[] opChars = new[] {'+', '-', '*', '^', '/', '=', '>', '<', '!', '(', ')'};

        public Lexer(string inp)
        {
            _inp = inp;
            _current = 0;
        }

        private bool CheckWord(string word)
        {
            for (int i = 0; i < word.Length; ++i)
            {
                if (!EOF && (CurrentChar == word[i])) ++_current;
                else
                {
                    // Console.WriteLine($"!!!{CurrentChar} {word[i]}");
                    return false;
                }
            }

            if (!EOF) --_current;
            return true;
        }

        private void CheckDigit()
        {
            while (!EOF && char.IsDigit(CurrentChar))
                ++_current;
            if (!EOF) --_current;
        }

        public bool IsValid()
        {
            char state = 'S';
            for (_current = 0; !EOF; ++_current)
            {
                if (CurrentChar == ' ') continue;
                if (state == 'S')
                {
                    if (opChars.Contains(CurrentChar)) continue;
                    if (CurrentChar == 'i')
                    {
                        // Console.WriteLine("if");
                        if (!CheckWord("if")) return false;
                    } else if (CurrentChar == 'e')
                    {
                        // Console.WriteLine("else");
                        if (!CheckWord("else")) return false;
                    } else if (CurrentChar == 't')
                    {
                        // Console.WriteLine("then");
                        if (!CheckWord("then")) return false;
                    } else if (char.IsDigit(CurrentChar))
                    {
                        CheckDigit();
                        state = 'A';
                    }
                    else return false;
                } else if (state == 'A')
                {
                    if (char.IsDigit(CurrentChar)) return false;
                    else
                    {
                        --_current;
                        state = 'S';
                    }
                }
                else return false;
            }

            return true;
        }
    }
}