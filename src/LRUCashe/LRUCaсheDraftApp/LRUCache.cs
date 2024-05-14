namespace LRUCacheDraftApp;

public class LruCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, int?> _cache;
    private readonly Dictionary<int, LinkedListNode<int>> _promoteCache;
    private readonly LinkedList<int> _orderList;

    public LruCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, int?>(capacity);
        _promoteCache = new Dictionary<int, LinkedListNode<int>>(capacity);
        _orderList = new LinkedList<int>();
    }

    public bool TryGetValue(int key, out int? value)
    {
        if (!_cache.ContainsKey(key))
        {
            value = null;
            return false;
        }

        Promote(key);
        value = _cache[key];
        return true;
    }

    public void Update(int key, int? value)
    {
        if (_cache.ContainsKey(key))
        {
            Promote(key);
            _cache[key] = value;
            return;
        }

        if (_cache.Count == _capacity) RemoveLast();
        AddFirst(key, value);
    }

    private void Promote(int key)
    {
        var node = _promoteCache[key];
        _orderList.Remove(node);
        _orderList.AddFirst(node);
    }

    private void RemoveLast()
    {
        var lastNode = _orderList.Last;
        _cache.Remove(lastNode!.Value);
        _promoteCache.Remove(lastNode.Value);
        _orderList.RemoveLast();
    }

    private void AddFirst(int key, int? value)
    {
        var node = new LinkedListNode<int>(key);
        _cache[key] = value;
        _promoteCache[key] = node;
        _orderList.AddFirst(node);
    }

    internal void ShowAll(string title)
    {
        Console.WriteLine(title);
        Console.WriteLine($"Cache count = {_cache.Count}, order count = {_orderList.Count} (capacity = {_capacity})");
        foreach (var key in _orderList) Console.WriteLine($"\t cache[{key}] = {_cache[key]}");
    }
}