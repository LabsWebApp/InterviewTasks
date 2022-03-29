//В задании не сказано, какого типа числа в узле,
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
    private T Add(T a, T b)
    {
        var paramA = Expression.Parameter(typeof(T), "a");
        var paramB = Expression.Parameter(typeof(T), "b");

        var body = Expression.Add(paramA, paramB);

        var add = Expression
            .Lambda<Func<T, T, T>>(body, paramA, paramB)
            .Compile();

        return add(a, b);
    }

    private T? Max(T? a, T? b) => (a, b) switch
    {
        (_, null) => a,
        (null, _) => b,
        _ => ((T)a).CompareTo((T)b) >= 0 ? a : b
    };

    public T MaxBranchSum(Node<T>? node) => node switch
    {
        null => default,
        _ => Add(
            Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) 
            ?? default, node.Value)
    };
}