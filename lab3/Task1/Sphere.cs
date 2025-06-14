namespace Task1;

public class Sphere : IGeometry
{
    public double Radius { get; }

    public Sphere(double radius) => Radius = radius;

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}