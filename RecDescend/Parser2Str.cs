using System.Text;

namespace RecDescend
{
    class Parser2Str : Parser2
    {
        public string Poliz => _sb.ToString();

        private readonly StringBuilder _sb;

        public Parser2Str(string inp) : base(inp)
        {
            _sb = new StringBuilder();
        }

        private protected override bool SemanticCall(string prod)
        {
            _sb.Append(prod);
            return true;
        }
    }
}