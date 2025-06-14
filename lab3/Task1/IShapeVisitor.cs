namespace Task1;

public interface IShapeVisitor
{
    void Visit(Sphere sphere);
    void Visit(Cube cube);
    void Visit(Parallelepiped box);
    void Visit(Torus torus);
}