using System.Diagnostics;
using BinarySearch;

Console.WriteLine("{1, 3, 5, 2, 10} - 10 => " + new int[] { 1, 3, 5, 2, 10 }
    .BinarySearchWithRotation(10)); 
Console.WriteLine("{1, 3, 5, 2, 10} - 9 => " + new int[] { 1, 3, 5, 2, 10 }
    .BinarySearchWithRotation(9)); 
Console.WriteLine("{1, 3, 5, 10} - 10 => " + new int[] { 1, 3, 5, 10 }
    .BinarySearchWithRotation(10));
Console.WriteLine("{1, 3, 5, -2, 10} - 10 => " + new int[] { 1, 3, 5, -2, 10 }
    .BinarySearchWithRotation(10));
Console.WriteLine("{1, 3, 5, -2, 10} -> 1 => " + new int[] { 1, 3, 5, -2, 10 }
    .BinarySearchWithRotation(1));
Console.ReadKey();