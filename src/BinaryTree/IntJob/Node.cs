//Решение не совсем полное (см BestJob),
//однако, для позиции Junior достаточна!
namespace IntJob;

public sealed record Node(int Value = 0, Node? Left = null, Node? Right = null)
{
    public static int MaxBranchSum(Node? node) => node switch
    {
        null => default,
        _ => Math.Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) + node.Value
    };
}