Node node = new(-0,
    new(5,
        new(1,
            new(10),
            new(9)),
        new(50)),
    new(13,
        new(5,
            new(8)),
        new(2)));

node.Print();

Console.WriteLine(Node.MaxBranchSum(node));
Console.WriteLine(Node.MaxBranchSumNoRecursive(node));
Console.WriteLine(Node.MaxPathSum(node));
//Console.WriteLine(Node.MaxPathSumNoRecursive(node));

var leaf1 = new Node(6);
var leaf2 = new Node(-5);
var leaf3 = new Node(2);
var leaf4 = new Node(-1);

var node1 = new Node(-4, leaf1, leaf2);
var node2 = new Node(5, leaf3, leaf4);

node = new Node(-10, node1, node2);

node.Print();

Console.WriteLine(Node.MaxPathSum(node));
//Console.WriteLine(Node.MaxPathSumNoRecursive(node));

Console.ReadLine();