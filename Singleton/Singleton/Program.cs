var single = Singleton.Instance;

var a = Singleton.Instance;

Console.WriteLine(a.Equals(single));

public class Singleton
{
    private static readonly object _lock = new();
    private static Singleton? _instance;
    private Singleton() { }
    public static Singleton Instance
    {
        get
        {
            if (_instance is not null)
                return _instance;
            lock (_lock)
            {
                if (_instance is not null)
                    return _instance;
                return _instance = new Singleton();
            }
        }
    }
}