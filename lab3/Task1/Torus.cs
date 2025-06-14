namespace Task1;

public class Torus : IGeometry
{
    public double MajorRadius { get; }
    public double MinorRadius { get; }

    public Torus(double majorRadius, double minorRadius)
    {
        MajorRadius = majorRadius;
        MinorRadius = minorRadius;
    }

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}