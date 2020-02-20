using System;
using System.Collections.Generic;
using System.Text;

namespace Enflatment
{
    internal interface ILeaf
    { }

    internal interface INode
    {
        List<Item> Items { get; }
    }

    internal class Item
    {
        public static Item[] GetYield(Item item)
        {
            Stack<Item> itemStack = new Stack<Item>(new[] { item });
            List<Item> itemList = new List<Item>();

            while (itemStack.Count > 0)
            {
                Item temp = itemStack.Pop();
                if (temp is INode node)
                {
                    for (var i = node.Items.Count - 1; i >= 0; i--)
                    {
                        itemStack.Push(node.Items[i]);
                    }
                }
                else if (temp is ILeaf)
                {
                    itemList.Add(temp);
                }
                else throw new NotSupportedException($"Item of type `{temp.GetType()}` is not supported");
            }

            return itemList.ToArray();
        }
    }

    internal class NumItem : Item, ILeaf, IComparable<NumItem>
    {
        public int Value { get; set; }

        public int CompareTo(NumItem other) => Value > other.Value ? 1 : Value < other.Value ? -1 : 0;

        public override string ToString() => $"{Value}";

        public NumItem() { }

        public NumItem(int value) => Value = value;

        public static NumItem operator +(NumItem left, NumItem right) => new NumItem(left.Value + right.Value);

        public static bool operator >(NumItem left, NumItem right) => left.CompareTo(right) == 1;

        public static bool operator <(NumItem left, NumItem right) => left.CompareTo(right) == -1;

        public static bool operator ==(NumItem left, NumItem right) => left.CompareTo(right) == 0;

        public static bool operator !=(NumItem left, NumItem right) => !(left == right);

        public static bool operator <=(NumItem left, NumItem right) => left == right || left < right;

        public static bool operator >=(NumItem left, NumItem right) => left == right || left > right;

        public static NumItem operator <<(NumItem left, int k) => new NumItem(left.Value << k);

        public static NumItem operator >>(NumItem left, int k) => new NumItem(left.Value >> k);
    }

    internal class ArrayItem : Item, INode
    {
        public List<Item> Items { get; } = new List<Item>();

        public ArrayItem(IEnumerable<Item> items) => Items.AddRange(items);

        public ArrayItem() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Item item in Items)
            {
                sb.Append(item + ", ");
            }

            if (sb.Length >= 2)
                sb.Remove(sb.Length - 2, 2);
            sb.Append("]");
            return sb.ToString();
        }
    }
}