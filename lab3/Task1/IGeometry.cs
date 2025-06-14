namespace Task1;

public interface IGeometry
{
    void Accept(IShapeVisitor visitor);
}