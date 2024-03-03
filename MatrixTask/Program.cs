namespace MatrixTask;

internal class Program
{
    static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(5, 5);

        Matrix matrix2 = new Matrix(matrix1);

        matrix2.Rows[0].VectorComponents[0] = 1;

        Console.WriteLine(matrix1.Rows[0].VectorComponents[0]);

        double[,] doubleArray = new double[2, 5] { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
        Matrix matrix3 = new Matrix(doubleArray);

        Console.WriteLine(matrix3.Rows[1].VectorComponents[1]);

    }


}
