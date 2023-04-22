Node node = new(6,
    new(2,
        new(1,
            new(10),
            new(7))),
    new(9,
        new(5,
            new(8)),
        new(2)));

//Console.WriteLine(Node.MaxBranchSum(node));
//Console.WriteLine(Node.MaxBranchSumNoRecursion(node));
//Console.WriteLine(Node.MaxPathSum(node));
//Console.WriteLine(Node.MaxPathSumNoRecursion(node));

var leaf1 = new Node(-3);
var leaf2 = new Node(-5);
var leaf3 = new Node(2);
var leaf4 = new Node(-1);

var node1 = new Node(-4, leaf1, leaf2);
var node2 = new Node(-5, leaf3, leaf4);

node = new Node(-10, node1, node2);

Console.WriteLine(Node.MaxPathSum(node));

Console.ReadLine();