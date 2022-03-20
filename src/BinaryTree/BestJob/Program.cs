using BestJob;

Node<int> node = new(6,
    new(2,
        new(1,
            new(10),
            new(7))),
    new(9,
        new(5,
            new(8)),
        new(2)));

Console.WriteLine(node.MaxBranchSum(node));

Node<double> nodeD = new(6.4,
    new(2, 
        new(1, 
            new(10), 
            new(7))), 
    new(9, 
        new(5, 
            new(8.1)), 
        new(2)));

Console.WriteLine(nodeD.MaxBranchSum(nodeD));
