namespace VectorTask;

internal class Program
{
    static void Main(string[] args)
    {
        Vector vector1 = new Vector(10);
        Console.WriteLine(vector1.GetSize());
        vector1.SetComponent(2, 3);
        Console.WriteLine(vector1.GetComponent(2));
        Console.WriteLine(vector1);

        double[] doubles = new double[] { 10, 11, 12, 13, 14 };
        Vector vector2 = new Vector(doubles);
        vector2.Add(vector1);
        Console.WriteLine(vector2);
        vector2.MultiplyByScalar(3);
        vector2.Subtract(vector1);
        Console.WriteLine(vector2);

        Vector vector3 = new Vector(15, doubles);
        vector3.Components[14] = 2;
        Console.WriteLine(vector3);

        Vector vector4 = new Vector(vector3);
        Console.WriteLine(vector4.Equals(vector3));

        Vector vector6 =  Vector.Add(vector3, vector4);
        Console.WriteLine(vector6);
        Console.WriteLine(Vector.MultiplyScalar(vector1,vector2));
    }
}
