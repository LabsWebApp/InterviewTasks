﻿// В задании не сказано, какого типа числа в узле,
// однако, известно, их можно суммировать и сравнивать ("будет максимальна"):
// числа - struct
// суммировать - Add
// сравнивать - IComparable

using System.Linq.Expressions;

namespace BestJob;

public sealed record class Node<T>(
    T Value = default, 
    Node<T>? Left = null, 
    Node<T>? Right = null)
    where T : struct, IComparable
{
    private static T Add(T x, T y)
    {
        var paramX = Expression.Parameter(typeof(T), "x");
        var paramY = Expression.Parameter(typeof(T), "y");

        var body = Expression.Add(paramX, paramY);

        var add = Expression
            .Lambda<Func<T, T, T>>(body, paramX, paramY)
            .Compile();

        return add(x, y);
    }

    private static T? Max(T? a, T? b) => (a, b) switch
    {
        (_, null) => a,
        (null, _) => b,
        _ => ((T)a).CompareTo((T)b) >= 0 ? a : b
    };

    public T MaxBranchSum(Node<T>? node) => node switch
    {
        null => default,
        _ => Add(Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) 
                 ?? default, node.Value)
    };
}