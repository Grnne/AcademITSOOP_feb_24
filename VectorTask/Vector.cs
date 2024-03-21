using System.Text;

namespace VectorTask;

public class Vector
{
    private double[] components;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), $"Must be more than zero components. Components amount = {size}");
        }

        components = new double[size];
    }

    public Vector(Vector vector) => components = (double[])vector.components.Clone();

    public Vector(double[] components)
    {
        if (components.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(components.Length), $"Must be more than zero components. Components amount = {components.Length}");
        }

        this.components = new double[components.Length];
        components.CopyTo(this.components, 0);
    }

    public Vector(int size, double[] vectorComponents)
    {
        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), $"Must be more than zero components. Components amount = {size}");
        }

        components = new double[size];
        vectorComponents.CopyTo(components, 0);

        for (int i = vectorComponents.Length; i < size; i++)
        {
            components[i] = 0;
        }
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector result = new Vector(vector1);
        result.Add(vector2);
        return result;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector result = new Vector(vector1);
        result.Subtract(vector2);
        return result;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        double result = 0;
        int smallestVectorLength = Math.Min(vector1.components.Length, vector2.components.Length);

        for (int i = 0; i < smallestVectorLength; i++)
        {
            result += vector1.components[i] * vector2.components[i];
        }

        return result;
    }

    public int GetSize() => components.Length;

    public double GetComponent(int index) => components[index];

    public void SetComponent(int index, double value)
    {
        components[index] = value;
    }

    public void Add(Vector vector)
    {
        if (vector.components.Length > components.Length)
        {
            double[] result = new double[vector.components.Length];
            components.CopyTo(result, 0);
            components = result;
        }

        for (int i = 0; i < vector.components.Length; i++)
        {
            components[i] += vector.components[i];
        }
    }

    public void Subtract(Vector vector)
    {
        if (vector.components.Length > components.Length)
        {
            double[] result = new double[vector.components.Length];
            components.CopyTo(result, 0);
            components = result;
        }

        for (int i = 0; i < vector.components.Length; i++)
        {
            components[i] -= vector.components[i];
        }
    }

    public void MultiplyByScalar(double number)
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i] *= number;
        }
    }

    public void Reverse()
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i] *= -1;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('{');

        for (int i = 0; i < components.Length - 1; i++)
        {
            stringBuilder.Append(components[i].ToString());
            stringBuilder.Append(", ");
        }

        stringBuilder.Append(components[components.Length - 1]);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
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

        Vector vector = (Vector)obj;

        if (components.Length != vector.components.Length)
        {
            return false;
        }

        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] != vector.components[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        int prime = 7;
        int hash = 1;

        foreach (double component in components)
        {
            hash = prime * hash + component.GetHashCode();
        }

        return hash;
    }
}