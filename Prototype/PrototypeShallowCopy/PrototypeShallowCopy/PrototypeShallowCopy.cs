var p = new Prototype(new List<int> {1, 2 ,3});
var pClone = p.Clone();

public class Prototype
{
    private readonly IReadOnlyCollection<int> _relatedEntityIds;
    public Prototype(IReadOnlyCollection<int> relatedEntityIds)
    {
        _relatedEntityIds = relatedEntityIds;
    }
    public Prototype Clone()
    {
        return new Prototype(_relatedEntityIds);
    }
}