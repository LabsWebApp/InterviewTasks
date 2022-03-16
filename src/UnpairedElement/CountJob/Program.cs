var source = new[] { 9, 88, -1, 7, -1, 1, 88, 7, 1, 7888, 9 };

//не могу оценить сложность - спросить у Н.В. Голковой !!!!!!!!!!!!!!!!!!!!
foreach (var i in source)
{
    if (source.Count(e => e == i) == 1)
    {
        Console.WriteLine(i);
        return;
    }
}