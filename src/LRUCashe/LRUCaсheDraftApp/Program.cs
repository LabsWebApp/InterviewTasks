// Рассмотрим частный случай - в кэше хранятся пары (int key, int value)

using LRUCacheDraftApp;

var cache = new LruCache(5);

cache.Update(1, 0);
cache.Update(2, 1);
cache.Update(3, 1);
cache.Update(4, 1);
cache.Update(5, 1);

cache.ShowAll("Init:");

cache.Update(2, 2);
cache.ShowAll("Put(2, 2):");

if (cache.TryGetValue(1,out var i)) Console.WriteLine($"cache[1] = {i}");
cache.ShowAll("TryGetValue(1,out var i):");

cache.Update(6, 1);
cache.ShowAll("Put(6, 1):");

cache.Update(6, 3);
cache.ShowAll("Put(6, 3):");

cache.Update(4, 4);
cache.ShowAll("Put(6, 4):");

cache.Update(int.MaxValue, 300);
cache.ShowAll("Put(MaxValue, 300):");

cache.Update(0, 1300);
cache.ShowAll("Put(0, 1300):");

cache.Update(int.MaxValue, -88);
cache.ShowAll("Put(MaxValue, -88):");

Console.ReadLine();