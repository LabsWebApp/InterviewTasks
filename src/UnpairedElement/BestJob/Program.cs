var source = new[] { 9, 88, -1, 7, -1, 1, 88, 7, 1, 7888, 9 };

//Сложность o(n)
var result = 0;
foreach (var element in source) result ^= element;

Console.WriteLine(result);