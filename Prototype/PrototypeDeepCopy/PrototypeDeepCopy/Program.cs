var first = new WrappedValue();
first.Value = 1;

var second = new WrappedValue();
second.Value = 2;

var third = new WrappedValue();
third.Value = 3;

var p = new DeepCopyPrototype(new List<WrappedValue>{first, second, third});

var deepCopyP = p.Clone();

public class WrappedValue
{
    public int Value { get; set; }
    public WrappedValue Clone()
        => new WrappedValue { Value = Value };
    
}

public class DeepCopyPrototype
{
    private readonly List<WrappedValue> _values;
    public DeepCopyPrototype(List<WrappedValue> values)
    {
        _values = values;
    }
    
    
    public DeepCopyPrototype Clone()
    {
        List<WrappedValue> values = _values.Select(x => x.Clone()).ToList();
        return new DeepCopyPrototype(values);
    }
}