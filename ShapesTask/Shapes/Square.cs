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

    public override string ToString()
    {
        return $"Это квадрат. Длина стороны:{Height:F2} Площадь: {GetArea():F2}; Периметр: {GetPerimeter():F2};";
    }
}