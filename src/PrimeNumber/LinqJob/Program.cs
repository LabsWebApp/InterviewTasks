const int end = 3000000;

Console.WriteLine(312471072265);

// Обратите внимание!
// Все проверки делались на int-перечислении
// и только в конце подсчёт аккумулировался в long,
// что существенно ускоряет и облегчает процесс.
var result = StepRange(3, end - 1, i => i + 2)
    .AsParallel()
    .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n))
        .All(j => n % j != 0))
    .Aggregate(2L, (x, y) => x + y);

Console.WriteLine(result);

static IEnumerable<int> StepRange(int start, int end, Func<int, int> step)
{
    while (start <= end)
    {
        yield return start;
        start = step(start);
    }
}

//Это переводилось на PLINQ:
/*
static IEnumerable<long> Primes()
{
    yield return 2;
    for (int i = 3; i <= end; i += 2)
    {
        if (IsPrime(i))
        {
            yield return i;
        }
    }
}

static bool IsPrime(int number)
{
    for (int j = 3; j * j <= number; j += 2)
        if (number % j == 0) return false;
    return true;
}
*/