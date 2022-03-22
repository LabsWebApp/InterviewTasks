const int end = 3000000;

Console.WriteLine(312471072265);

bool IsPrime(int n)
{
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    int i = 3;
    while (i * i <= n)
    {
        if (n % i == 0) return false;
        i += 2;
    }

    return true;
}

long result = 0;
int i = 2;

while (i <= end)
{
    if (IsPrime(i)) result += i;
    i++;
}

Console.WriteLine(result);