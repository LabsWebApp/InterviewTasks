namespace LinqJob;

public static class Prime
{
    public static IEnumerable<T> StepRange<T>(T start, T end, Func<T, T> step)
        where T : IComparable
    {
        while (start.CompareTo(end) <= 0)
        {
            yield return start;
            start = step(start);
        }
    }

    // Обратите внимание!
    // Все проверки делались на int-перечислении
    // и только в конце подсчёт аккумулировался в long,
    // что существенно ускоряет и облегчает процесс.
    public static long PSum(int max) =>
        StepRange(3, max, i => i + 2)
            .AsParallel()
            .Where(j => StepRange(3, (int)Math.Sqrt(j), i => i + 2)
                .All(k => j % k != 0))
            .Aggregate(2L, (x, y) => x + y);

    public static long Sum(int max) =>
        StepRange(3, max, i => i + 2)
            .Where(j => StepRange(3, (int)Math.Sqrt(j), i => i + 2)
                .All(k => j % k != 0))
            .Aggregate(2L, (x, y) => x + y);
}