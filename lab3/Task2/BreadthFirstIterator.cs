using System.Collections;

namespace Task2;

public class BreadthFirstIterator<T> : IEnumerator<TreeNode<T>>
{
    private readonly Queue<TreeNode<T>> _queue = new();
    private TreeNode<T>? _current;

    public BreadthFirstIterator(TreeNode<T> root)
    {
        if (root != null)
            _queue.Enqueue(root);
    }

    public TreeNode<T> Current => _current!;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_queue.Count == 0)
            return false;

        _current = _queue.Dequeue();

        foreach (var child in _current.Children)
            _queue.Enqueue(child);

        return true;
    }

    public void Reset() => throw new NotSupportedException();
    public void Dispose() { }
}