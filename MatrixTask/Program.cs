namespace MatrixTask;

internal class Program
{
    static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(5, 5);

        Matrix matrix2 = new Matrix(matrix1);


        
        double[,] doubleArray = new double[3, 5] { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } , { 2, 3, 4, 5, 6 } };
        Matrix matrix3 = new Matrix(doubleArray);

        Console.WriteLine(matrix3);

        //Console.WriteLine(matrix3.GetVectorRow(1)); ;
        
        //foreach (var mat in matrix3.Rows)
        //{
        //    Console.WriteLine(mat);
        //}


    }


}
