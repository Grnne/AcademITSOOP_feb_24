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

    public override string ToString()
    {
        return $"Это Прямоугольник. Площадь: {GetArea():F2}; Периметр: {GetPerimeter():F2}; Ширина: {GetWidth():F2}; Высота: {GetHeight():F2};";
    }
}