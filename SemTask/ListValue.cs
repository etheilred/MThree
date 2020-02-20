namespace SemTask
{
    internal class ListValue : UnifiedValue
    {
        public ListNode List { get; set; }

        public ListValue()
        {
            Type = ValueType.List;
        }

        public override string ToString()
        {
            return $"({List})";
        }
    }
}