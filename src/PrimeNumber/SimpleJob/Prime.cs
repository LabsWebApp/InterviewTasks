namespace SimpleJob;

public static class Prime
{
    internal static bool IsPrime(int n)
    {
        //if (n == 2) return true;
        if (n % 2 == 0) return false;

        var i = 3;
        while (i * i <= n)
        {
            if (n % i == 0) return false;
            i += 2;
        }

        return true;
    }

    public static long ParallelSum(int max)
    {
        long result = 2;
        object locker = new();

        Parallel.For(3, ++max, n =>
        {
            if (!IsPrime(n)) return;
            lock (locker)
            {
                result += n;
            }
        });

        return max switch
        {
            < 2 => 0,
            2 => 2,
            _ => result
        };
    }

    public static long Sum(int max)
    {
        long result = 2;
        var i = 3;

        while (i <= max)
        {
            if (IsPrime(i)) result += i;
            i += 2;
        }

        return max switch
        {
            < 2 => 0,
            2 => 2,
            _ => result
        };
    }
}