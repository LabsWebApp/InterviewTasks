using System.Text;

namespace IntJob;

public sealed record Node(int Value = 0, Node? Left = null, Node? Right = null)
{
    #region Recursive Methods
    public static int MaxBranchSum(Node? node) => node switch
    {
        null => 0,
        _ => Math.Max(MaxBranchSum(node.Left), MaxBranchSum(node.Right)) + node.Value
    };


    public static int MaxPathSum(Node? node)
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
    #endregion

    #region Not Recursive Methods
    public static int MaxPathSumNotRecursive(Node? node)
    {
        if (node == null) return 0;

        var result = int.MinValue;
        var stack = new Stack<(Node? Node, bool Visited, int MaxPathSum)>();
        stack.Push((node, false, 0));

        while (stack.Count > 0)
        {
            var (current, visited, maxPathSum) = stack.Pop();

            if (current != null)
            {
                if (visited)
                {
                    maxPathSum = Math.Max(Math.Max(maxPathSum + current.Value, current.Value), 0);
                    result = Math.Max(result, maxPathSum);
                }
                else
                {
                    stack.Push((current, true, maxPathSum));
                    stack.Push((current.Right, false, maxPathSum + current.Value));
                    stack.Push((current.Left, false, maxPathSum + current.Value));
                }
            }
        }

        return result;
    }


    public static int MaxBranchSumNotRecursive(Node? node)
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
                var newLeft = new Node(
                    current.Left.Value + current.Value,
                    current.Left.Left, current.Left.Right);
                stack.Push(newLeft);
            }

            if (current.Right != null)
            {
                var newRight = new Node(
                    current.Right.Value + current.Value,
                    current.Right.Left, current.Right.Right);
                stack.Push(newRight);
            }

            if (current.Left == null && current.Right == null)
                result = Math.Max(result, current.Value);
        }

        return result;
    }

    #endregion
}