const long end = 3000000L;

Console.WriteLine(312471072265);

bool IsPrime(long n)
{
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    long i = 3;
    while (i * i <= n)
    {
        if (n % i == 0) return false;
        i += 2;
    }

    return true;
}

long result = 0;
long i = 2;

while (i <= end)
{
    if (IsPrime(i)) result += i;
    i++;
}

Console.WriteLine(result);