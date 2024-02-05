namespace ShapesTask;

internal class Square : IShape
{
    public double Height { get; set; }

    public Square(double height)
    {
        Height = height;
    }

    public double GetWidth() => Height;

    public double GetHeight() => Height;

    public double GetArea() => Height * Height;

    public double GetPerimeter() => Height * 4;
}