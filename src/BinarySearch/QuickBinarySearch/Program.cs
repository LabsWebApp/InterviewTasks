using QuickBinarySearch;

Console.WriteLine("{1, 3, 5, 2, 10} - 10 => " + new int[] { 1, 3, 5, 2, 10 }
    .BinarySearchWithRotation(10));
Console.WriteLine("{1, 3, 5, 2, 10} - 9 => " + new int[] { 1, 3, 5, 2, 10 }
    .BinarySearchWithRotation(9));
Console.WriteLine("{1, 3, 5, 10} - 10 => " + new int[] { 1, 3, 5, 10 }
    .BinarySearchWithRotation(10));
Console.WriteLine("{1, 3, 5, -2, 10} - 10 => " + new int[] { 1, 3, 5, -2, 10 }
    .BinarySearchWithRotation(10));
Console.WriteLine("{1, 3, 5, -2, 10} -> -2 => " + new int[] { 1, 3, 5, -2, 10 }
    .BinarySearchWithRotation(-2));
Console.WriteLine("{1, 3, 5, -2, 1, 10} -> -2 => " + new int[] { 1, 3, 5, -2, 1, 10 }
    .BinarySearchWithRotation(-2));
Console.WriteLine("{1, 3, 5, -2, 1, 3, 10} -> -2 => " + new int[] { 1, 3, 5, -2, 1, 3, 10 }
    .BinarySearchWithRotation(-2));
Console.WriteLine("{1, 3, 5,-4, -2, 10} -> -2 => " + new int[] { 1, 3, 5,-4, -2, 10 }
    .BinarySearchWithRotation(-2));
Console.WriteLine("{1, 3, 5,-4, -2, 1, 10} -> -2 => " + new int[] { 1, 3, 5, -4, -2, 1, 10 }
    .BinarySearchWithRotation(-2));
Console.WriteLine("{1, 3, 5,-4, -2, 1, 3, 10} -> -2 => " + new int[] { 1, 3, 5, -4, -2, 1, 3, 10 }
    .BinarySearchWithRotation(-2));
Console.ReadKey();