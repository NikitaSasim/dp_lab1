using Task1;

var shapes = new List<IGeometry>
{
    new Sphere(3),
    new Cube(2),
    new Parallelepiped(2, 4, 3),
    new Torus(5, 1)
};

foreach (var shape in shapes)
{
    var calculator = new VolumeCalculator();
    shape.Accept(calculator);
    Console.WriteLine($"{shape.GetType().Name} volume: {calculator.Volume}");
}