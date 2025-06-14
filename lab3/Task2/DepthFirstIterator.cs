using System.Collections;

namespace Task2;

public class DepthFirstIterator<T> : IEnumerator<TreeNode<T>>
{
    private readonly Stack<TreeNode<T>> _stack = new();
    private TreeNode<T>? _current;

    public DepthFirstIterator(TreeNode<T> root)
    {
        if (root != null)
            _stack.Push(root);
    }

    public TreeNode<T> Current => _current!;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_stack.Count == 0)
            return false;

        _current = _stack.Pop();

        for (int i = _current.Children.Count - 1; i >= 0; i--)
            _stack.Push(_current.Children[i]);

        return true;
    }

    public void Reset() => throw new NotSupportedException();
    public void Dispose() { }
}