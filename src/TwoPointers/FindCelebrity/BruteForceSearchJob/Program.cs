// Полный перебор.
// Не является решением: "оптимальным способом"

// Представляем людей в виде матрицы  n * n,
// где значение ячейки показывает знает ли персона другую или нет
// (последний является альтернативно одарённым - сам себя не знает))) )
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
    var candidate = -1;
    for (var i = 0; i < persons.GetLength(0); i++)
    {
        candidate = i;
        for (var j = 0; j < persons.GetLength(1); j++)
        {
            if (!persons[i, j] || i == j) continue;
            candidate = -1;
            break;
        }
        if (candidate >= 0) break;
    }
    if (candidate < 0) return -1;

    for (var j = 0; j < persons.GetLength(1); j++)
        if (j != candidate && persons[candidate, j]) return -1;

    return candidate;
}
// Сложность o(n^2 + n)) !!!!!!!!!!!!!!!!! 