namespace ShapesTask.Shapes;

public class Rectangle : IShape
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

    public double GetPerimeter() => (Height + Width) * 2;

    public override string ToString()
    {
        return $"Прямоугольник. Ширина: {GetWidth():F2}; Высота: {GetHeight():F2}; Площадь: {GetArea():F2}; Периметр: {GetPerimeter():F2};";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        Rectangle rectangle = (Rectangle)obj;

        return Width == rectangle.Width && Height == rectangle.Height;
    }

    public override int GetHashCode()
    {
        int prime = 7;
        int hash = 1;

        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

        return hash;
    }
}