namespace ShapesTask;

internal class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetWidth() => Radius * 2;

    public double GetHeight() => Radius * 2;

    public double GetArea() => Radius * Radius * Math.PI;

    public double GetPerimeter() => 2 * Radius * Math.PI;

}