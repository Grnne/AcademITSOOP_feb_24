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
        VectorComponents = new double[VectorComponents.Length];
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

    public int GetSize() => VectorComponents.Length;

    public override string ToString() => string.Join(", ", VectorComponents);
}