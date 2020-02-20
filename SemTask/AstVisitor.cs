namespace SemTask
{
    internal interface AstVisitor
    {
        UnifiedValue Visit(RootNode node);
        UnifiedValue Visit(ListNode node);
        UnifiedValue Visit(QuotedNode node);
        UnifiedValue Visit(AtomNode node);
        UnifiedValue Visit(dynamic node);
    }
}