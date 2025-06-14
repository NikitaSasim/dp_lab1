namespace Task2;

public class TreeNode<T>
{
    public T Value { get; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }
}