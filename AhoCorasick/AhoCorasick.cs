using System;
using System.Collections.Generic;
using System.Text;

namespace AhoCorasick
{
    internal class AhoCorasick
    {
        private readonly Node _root = new Node();
        public AhoCorasick() { }

        public AhoCorasick(IEnumerable<string> toAdd)
        {
            foreach (var s in toAdd)
            {
                if (s.Length == 0)
                    throw new ArgumentException("String to add cannot be null");
                AddString(s);
            }
        }

        public override string ToString()
        {
            return _root.ToString();
        }

        public void AddString(string s)
        {
            Node t = _root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (t.Next.ContainsKey(s[i]) && t.Next[s[i]] != null)
                    t = t.Next[s[i]];
                else
                {
                    t.Next.Add(s[i], new Node {Parent = t, ParentChar = s[i]});
                    t = t.Next[s[i]];
                }
            }

            t.IsLeaf = true;
        }

        public Node GetLink(Node node)
        {
            if (node != null && node.Link != null)
            {
                if (node == _root || node.Parent == _root)
                    node.Link = _root;
                else node.Link = Go(GetLink(node.Parent), node.ParentChar);
            }

            return node?.Link;
        }

        public Node Go(Node node, char c)
        {
            if (node != null && !node.Go.ContainsKey(c))
            {
                if (node.Next.ContainsKey(c))
                    node.Go[c] = node.Next[c];
                else node.Go[c] = node == _root ? _root : Go(GetLink(node), c);
            }

            return node?.Go[c];
        }
    }

    class Node
    {
        public Dictionary<char, Node> Next { get; } = new Dictionary<char, Node>();
        public Dictionary<char, Node> Go { get; } = new Dictionary<char, Node>();
        public bool IsLeaf { get; set; } = false;
        public Node Parent { get; set; } = null;
        public char ParentChar { get; set; }
        public Node Link { get; set; } = null;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Next.Count == 0) return "";
            sb.Append("(");
            foreach (KeyValuePair<char, Node> pair in Next)
            {
                sb.Append($"{pair.Key}{(pair.Value.IsLeaf?"!":"")}{(pair.Value.Next.Count>0?$" {pair.Value}":"")} ");
            }

            sb.Remove(sb.Length-1, 1);

            sb.Append(")");
            return sb.ToString();
        }
    }
}