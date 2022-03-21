﻿//В задании не сказано, какого типа числа в узле,
//однако, известно, их можно суммировать и сравнивать ("будет максимальна"):
//числа - struct
//суммировать - Add
//сравнивать - IComparable

using System.Linq.Expressions;

namespace BestJob;

public sealed record Node<T>(
    T Value = default, 
    Node<T>? Left = null, 
    Node<T>? Right = null)
    where T : struct, IComparable
{
    public T Add(T a, T b)
    {
        var paramA = Expression.Parameter(typeof(T), "a");
        var paramB = Expression.Parameter(typeof(T), "b");

        BinaryExpression body = Expression.Add(paramA, paramB);

        Func<T, T, T> add = Expression
            .Lambda<Func<T, T, T>>(body, paramA, paramB)
            .Compile();

        return add(a, b);
    }

    public T? Max(T? a, T? b) => (a, b) switch
    {
        (null, _) => b,
        (_, null) => a,
        _ => a.Value.CompareTo(b.Value) >= 0 ? a : b
    };

    public T MaxBranchSum(Node<T>? node) => node switch
    {
        null => default,
        _ => Add(
            Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) ?? default, 
            node.Value)
    };
}