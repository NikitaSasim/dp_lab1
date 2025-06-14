namespace Task1;

public class Cube : IGeometry
{
    public double Side { get; }

    public Cube(double side) => Side = side;

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}