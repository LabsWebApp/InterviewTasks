var source = new[] { 9, 88, -1, 7, -1, 1, 88, 7, 1, 1000, 9 , 10, 10};

//"один элемент непарный", значит как минимум он существует!
if (source.Length == 1)
{
    Console.WriteLine(source[0]);
    return;
}

//сложность сортировки o(n*ln2n), c# использует быструю сортировку(?)
source = source.OrderBy(n => n).ToArray();

//перебор вроде(?) не входит в сложность
//"один элемент непарный", значит выйдет из цикла
for (var i = 0;;)
{
    if (i + 1 == source.Length || source[i] != source[i + 1])
    {
        Console.WriteLine(source[i]);
        return;
    }
    i += 2;
}