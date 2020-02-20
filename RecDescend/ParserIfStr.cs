using System.Text;

namespace RecDescend
{
    class ParserIfStr : ParserIf
    {
        private StringBuilder _sb = new StringBuilder();

        public string Poliz => _sb.ToString();

        public ParserIfStr(string inp) : base(inp) { }

        private protected override bool SemanticCall(string prod)
        {
            _sb.Append(prod);
            return true;
        }
    }
}