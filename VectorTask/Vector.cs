namespace VectorTask;

public class Vector
{
    public double[] VectorComponents { get; set; }

    public Vector(int n)
    {
        VectorComponents = new double[n];
    }

    public Vector(Vector vector)
    {
        VectorComponents = new double[vector.VectorComponents.Length];
        vector.VectorComponents.CopyTo(VectorComponents, 0);
    }

    public Vector(double[] vectorComponents)
    {
        VectorComponents = new double[vectorComponents.Length];
        vectorComponents.CopyTo(VectorComponents, 0);
    }

    public Vector(double[] vectorComponents, int n)
    {
        VectorComponents = new double[n];
        vectorComponents.CopyTo(VectorComponents, 0);

        for (int i = vectorComponents.Length; i < n; i++)
        {
            VectorComponents[i] = 0;
        }
    }

    public static void Add(Vector vector1, Vector vector2)
    { }

    public static void Subtract(Vector vector1, Vector vector2)
    { }

    public static void MultiplyScalar(Vector vector1, Vector vector2)
    { }

    public override string ToString() => string.Join(", ", VectorComponents);

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int GetSize() => VectorComponents.Length;

    //public int Add()
    //{ }

    //public int Subtract()
    //{ }

    //public int MultiplyByScalar()
    //{ }

    //public int Reverse()
    //{ }

    //public int GetLength()
    //{ }

    //public int GetComponent()
    //{ }

    public void SetComponent()
    { }
}