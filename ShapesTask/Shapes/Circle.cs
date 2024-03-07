namespace ShapesTask.Shapes;

public class Circle : IShape
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

    public override string ToString()
    {
        return $"Круг. Диаметр: {GetWidth():F2}; Радиус: {Radius:F2}; Площадь: {GetArea():F2}; Длина окружности: {GetPerimeter():F2};";
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

        Circle circle = (Circle)obj;

        return Radius == circle.Radius;
    }

    public override int GetHashCode()
    {
        int prime = 7;
        int hash = 1;

        hash = prime * hash + Radius.GetHashCode();

        return hash;
    }
}