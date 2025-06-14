using Task2;

var root = new TreeNode<string>("A");
var b = new TreeNode<string>("B");
var c = new TreeNode<string>("C");
var d = new TreeNode<string>("D");
var e = new TreeNode<string>("E");
var f = new TreeNode<string>("F");

root.AddChild(b);
root.AddChild(c);
b.AddChild(d);
b.AddChild(e);
c.AddChild(f);

var treeDfs = new Tree<string>(root, TraversalMode.DepthFirst);
Console.WriteLine("DFS:");
foreach (var node in treeDfs)
    Console.WriteLine(node.Value);

var treeBfs = new Tree<string>(root, TraversalMode.BreadthFirst);
Console.WriteLine("\nBFS:");
foreach (var node in treeBfs)
    Console.WriteLine(node.Value);
