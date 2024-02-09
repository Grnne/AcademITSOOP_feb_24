namespace VectorTask;

internal class Program
{
    static void Main(string[] args)
    {
        Vector vector1 = new Vector(5);
        Vector vector2 = new Vector(vector1);
        vector2.VectorComponents = new double[] { 1, 2, 3, 4, 5 };
        Vector vector3 = new Vector(vector2.VectorComponents, 10);
        

        Console.WriteLine(vector3);
    }
}
