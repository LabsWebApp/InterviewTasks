//Представляем людей в виде матрицы  n * n,
//где значение ячейки показывает знает ли персона другую или нет
//(последний является альтернативно одарённым - сам себя не знает) )
bool[,] persons = 
{ 
    { true, false, true, false, true },
    { false, true, true, false , true},
    { false, false, true, false, false },
    { true, true, true, true , true},
    { false, false, true, false , false}
};

var result = FindCelebrity(persons);

Console.Write(
    result == -1 ? 
        "Знаменитостей нет!" : 
        $"Персона № {result} является знаменитостью.");

static int FindCelebrity(bool[,] persons)
{
    var n = persons.GetLength(0);
    
    //Два указателя:
    int candidate = 0, last = n - 1;
    while (candidate < last)
    {
        if (persons[last, candidate])
            last--;
        else
            candidate++;
    }

    for (var i = 0; i < n; i++)
    {
        if (i == candidate) continue;
        if (!persons[i, candidate] || persons[candidate, i]) return -1;
    }

    return candidate;
}

//Сложность o(n), память o(2) !!!!!!!