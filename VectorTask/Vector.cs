namespace VectorTask;

public class Vector
{
    public double[] Components { get; set; }

    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero components.");
        }

        Components = new double[n];
    }

    public Vector(Vector vector)
    {
        Components = new double[vector.Components.Length];
        Components = (double[])vector.Components.Clone();
    }

    public Vector(double[] components)
    {
        if (components.Length <= 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero components.");
        }

        Components = new double[components.Length];
        components.CopyTo(Components, 0);
    }

    public Vector(int n, double[] vectorComponents)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero components.");
        }

        Components = new double[n];
        vectorComponents.CopyTo(Components, 0);

        for (int i = vectorComponents.Length; i < n; i++)
        {
            Components[i] = 0;
        }
    }

    public static Vector Add(Vector vector1, Vector vector2)
    {
        Vector result = new Vector(vector1);
        result.Add(vector2);
        return result;
    }

    public static Vector Subtract(Vector vector1, Vector vector2)
    {
        Vector result = new Vector(vector1);
        result.Subtract(vector2);
        return result;
    }

    public static double MultiplyScalar(Vector vector1, Vector vector2)
    {
        double result = 0;

        for (int i = 0; i < Math.Min(vector1.GetSize(), vector2.GetSize()); i++)
        {
            result += vector1.Components[i] * vector2.Components[i];
        }

        return result;
    }

    public int GetSize() => Components.Length;

    public double GetComponent(int index) => Components[index];

    public void SetComponent(int index, double value)
    {
        Components[index] = value;
    }

    public void Add(Vector vector)
    {
        if (vector.GetSize() > this.GetSize())
        {
            double[] result = new double[vector.GetSize()];
            Components.CopyTo(result, 0);
            Components = result;
        }

        for (int i = 0; i < vector.GetSize(); i++)
        {
            Components[i] += vector.Components[i];
        }
    }

    public void Subtract(Vector vector)
    {
        if (vector.GetSize() > this.GetSize())
        {
            double[] result = new double[vector.GetSize()];
            Components.CopyTo(result, 0);
            Components = result;
        }

        for (int i = 0; i < vector.GetSize(); i++)
        {
            Components[i] -= vector.Components[i];
        }
    }

    public void MultiplyByScalar(double number)
    {
        for (int i = 0; i < Components.Length; i++)
        {
            Components[i] *= number;
        }
    }

    public void Reverse() => Components.Reverse();

    public override string ToString() => "{" + string.Join(", ", Components) + "}";

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

        if (GetSize() != vector.GetSize())
        {
            return false;
        }

        for (int i = 0; i < Components.Length; i++)
        {
            if (Components[i] != vector.Components[i])
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

        foreach (var component in Components)
        {
            hash = prime * hash + component.GetHashCode();
        }

        return base.GetHashCode();
    }
}