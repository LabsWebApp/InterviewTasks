namespace IntJob;

public static class NodePrinterExtension
{
    private class NodeInfo
    {
        public Node? Node;
        public string? Text;
        public int StartPos;
        private int Size => Text?.Length ?? 0;
        public int EndPos 
        { 
            get => StartPos + Size;
            set => StartPos = value - Size;
        }
        public NodeInfo? Parent, Left, Right;
    }

    public static void Print(
        this Node? root, 
        string textFormat = "0", 
        int spacing = 1, 
        int topMargin = 0, 
        int leftMargin = 1,
        bool bottomMargin = true)
    {
        if (root == null) return;
        var rootTop = Console.CursorTop + topMargin;
        var last = new List<NodeInfo>();
        var next = root;
        for (var level = 0; next != null; level++)
        {
            var item = new NodeInfo { Node = next, Text = next.Value.ToString(textFormat) };
            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + spacing;
                last[level] = item;
            }
            else
            {
                item.StartPos = leftMargin;
                last.Add(item);
            }
            if (level > 0)
            {
                item.Parent = last[level - 1];
                if (next == item.Parent.Node?.Left)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                }
            }
            next = next.Left ?? next.Right;
            for (; next == null; item = item.Parent)
            {
                var top = rootTop + 2 * level;
                Print(item.Text, top, item.StartPos);
                if (item.Left != null)
                {
                    Print("/", top + 1, item.Left.EndPos);
                    Print("_", top, item.Left.EndPos + 1, item.StartPos);
                }
                if (item.Right != null)
                {
                    Print("_", top, item.EndPos, item.Right.StartPos - 1);
                    Print("\\", top + 1, item.Right.StartPos - 1);
                }
                if (--level < 0) break;
                if (item == item.Parent?.Left)
                {
                    item.Parent.StartPos = item.EndPos + 1;
                    next = item.Parent.Node?.Right;
                }
                else
                {
                    if (item.Parent?.Left == null)
                        item.Parent.EndPos = item.StartPos - 1;
                    else
                        item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                }
            }
        }
        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        if (bottomMargin) Console.WriteLine();
    }

    private static void Print(string? s, int top, int left, int right = -1)
    {
        if (s == null) return;
        Console.SetCursorPosition(left, top);
        if (right < 0) right = left + s.Length;
        while (Console.CursorLeft < right) Console.Write(s);
    }
}