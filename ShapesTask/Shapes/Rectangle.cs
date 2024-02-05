namespace ShapesTask;

internal class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetWidth() => Width;

    public double GetHeight() => Height;

    public double GetArea() => Width * Height;

    public double GetPerimeter() => Height * 2 + Width * 2;
}