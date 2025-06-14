namespace Task1;

public class VolumeCalculator : IShapeVisitor
{
    public double Volume { get; private set; }

    public void Visit(Sphere sphere)
    {
        Volume = (4.0 / 3.0) * Math.PI * Math.Pow(sphere.Radius, 3);
    }

    public void Visit(Cube cube)
    {
        Volume = Math.Pow(cube.Side, 3);
    }

    public void Visit(Parallelepiped box)
    {
        Volume = box.Width * box.Height * box.Depth;
    }

    public void Visit(Torus torus)
    {
        Volume = 2 * Math.PI * Math.PI * torus.MajorRadius * Math.Pow(torus.MinorRadius, 2);
    }
}