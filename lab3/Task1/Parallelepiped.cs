namespace Task1;

public class Parallelepiped : IGeometry
{
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }

    public Parallelepiped(double width, double height, double depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}