//Решение не совсем полное (см BestJob),
//однако, для позиции Junior достаточна!
namespace IntJob;

public sealed record Node(int Value = 0, Node? Left = null, Node? Right = null)
{
    public static int MaxBranchSum(Node? node) => node switch
    {
        null => 0,
        _ => Math.Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) + node.Value
    };

    public static int _MaxPathSum(Node? node)
    {
        if (node == null) return 0;
        var result = 0;

        int TailCall(Node? tail)
        {
            if (tail == null) return 0;

            var maxLeftPath = Math.Max(TailCall(tail.Left), 0);
            var maxRightPath = Math.Max(TailCall(tail.Right), 0);

            result = Math.Max(result, maxLeftPath + maxRightPath + tail.Value);
            return Math.Max(maxLeftPath, maxRightPath) + tail.Value;
        }

        TailCall(node);

        return result;
    }

    public static int MaxBranchSumNoRecursion(Node? node)
    {
        if (node == null) return 0;

        var stack = new Stack<Node>();
        stack.Push(node);
        var result = 0;

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.Left != null)
            {
                var newLeft = new Node(current.Left.Value + current.Value, current.Left.Left, current.Left.Right);
                stack.Push(newLeft);
            }

            if (current.Right != null)
            {
                var newRight = new Node(current.Right.Value + current.Value, current.Right.Left, current.Right.Right);
                stack.Push(newRight);
            }

            if (current.Left == null && current.Right == null)
            {
                result = Math.Max(result, current.Value);
            }
        }

        return result;
    }

    public static int MaxPathSum(Node? node)
    {
        if (node == null) return 0;

        var stack = new Stack<Node>();
        stack.Push(node);
        var result = int.MinValue;

        while (stack.Count > 0)
        {
            var curr = stack.Pop();

            if (curr.Left != null)
            {
                var newLeft = new Node(curr.Left.Value, curr.Left.Left, curr.Left.Right);
                newLeft = new Node(newLeft.Value + curr.Value, newLeft.Left, newLeft.Right);
                stack.Push(newLeft);
            }

            if (curr.Right != null)
            {
                var newRight = new Node(curr.Right.Value, curr.Right.Left, curr.Right.Right);
                newRight = new Node(newRight.Value + curr.Value, newRight.Left, newRight.Right);
                stack.Push(newRight);
            }

            if (curr.Left == null && curr.Right == null)
            {
                result = Math.Max(result, curr.Value);
            }
            else if (curr.Left != null && curr.Right != null)
            {
                result = Math.Max(result, Node.MaxBranchSum(curr.Left) + Node.MaxBranchSum(curr.Right) + curr.Value);
            }
            else if (curr.Left != null)
            {
                result = Math.Max(result, Node.MaxBranchSum(curr.Left) + curr.Value);
            }
            else if (curr.Right != null)
            {
                result = Math.Max(result, Node.MaxBranchSum(curr.Right) + curr.Value);
            }
        }

        return result;
    }

}
