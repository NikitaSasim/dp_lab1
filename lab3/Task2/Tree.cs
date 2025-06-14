using System.Collections;

namespace Task2;

public class Tree<T> : IEnumerable<TreeNode<T>>
{
    private readonly TreeNode<T> _root;
    private readonly TraversalMode _mode;

    public Tree(TreeNode<T> root, TraversalMode mode = TraversalMode.DepthFirst)
    {
        _root = root;
        _mode = mode;
    }

    public IEnumerator<TreeNode<T>> GetEnumerator()
    {
        return _mode switch
        {
            TraversalMode.DepthFirst => new DepthFirstIterator<T>(_root),
            TraversalMode.BreadthFirst => new BreadthFirstIterator<T>(_root),
            _ => throw new NotImplementedException()
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}