namespace ShapesTask.Shapes;

public class Triangle : IShape
{
    public double X1 { get; set; }

    public double Y1 { get; set; }

    public double X2 { get; set; }

    public double Y2 { get; set; }

    public double X3 { get; set; }

    public double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    public double GetWidth() => Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);

    public double GetHeight() => Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);

    public double GetArea() => Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1)) / 2;

    public double GetPerimeter()
    {
        double side1Length = GetSideLength(X1, Y1, X2, Y2);
        double side2Length = GetSideLength(X1, Y1, X3, Y3);
        double side3Length = GetSideLength(X2, Y2, X3, Y3);

        return side1Length + side2Length + side3Length;
    }

    private static double GetSideLength(double x1, double y1, double x2, double y2) =>
            Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

    public override string ToString()
    {
        return $"Треугольник. Координаты вершин: ({X1:F2}; {Y1:F2}), ({X2:F2}; {Y2:F2}), ({X3:F2}; {Y3:F2}); Ширина: " +
            $"{GetWidth():F2}; Высота: {GetHeight():F2}; Площадь: {GetArea():F2}; Периметр: {GetPerimeter():F2}";
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

        Triangle triangle = (Triangle)obj;

        return X1 == triangle.X1 && Y1 == triangle.Y1
            && X2 == triangle.X2 && Y2 == triangle.Y2
            && X3 == triangle.X3 && Y3 == triangle.Y3;
    }

    public override int GetHashCode()
    {
        int prime = 21;
        int hash = 1;

        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

        return hash;
    }
}