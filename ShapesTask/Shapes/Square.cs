﻿namespace ShapesTask.Shapes;

public class Square : IShape
{
    public double SideLength { get; set; }

    public Square(double height)
    {
        SideLength = height;
    }

    public double GetWidth() => SideLength;

    public double GetHeight() => SideLength;

    public double GetArea() => SideLength * SideLength;

    public double GetPerimeter() => SideLength * 4;

    public override string ToString()
    {
        return $"Квадрат. Длина стороны: {SideLength:F2}; Площадь: {GetArea():F2}; Периметр: {GetPerimeter():F2};";
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

        Square square = (Square)obj;

        return SideLength == square.SideLength;
    }

    public override int GetHashCode()
    {
        int prime = 7;
        int hash = 1;

        hash = prime * hash + SideLength.GetHashCode();

        return hash;
    }
}