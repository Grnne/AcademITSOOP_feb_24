using VectorTask;
using MatrixTask;
using System.Numerics;

namespace TrashCan;

internal class Program
{
    static void Main(string[] args)
    {
        
Console.WriteLine($"The number of columns in the first matrix must be equal to the number of rows in the second matrix.{Environment.NewLine}" +
                $"First matrix rows and columns amount: {1} {1}{Environment.NewLine}" +
                $"Second matrix rows and columns amount: {2} {2}");






        //public static int Determinant(int[][] matrix)
        //{
        //    int det = 0;
        //    if (matrix.Length != matrix[0].Length)
        //        return -1;
        //    if (matrix.Length == 1)
        //        return matrix[0][0];

        //    for (int i = 0; i < matrix.Length; i++)
        //        det += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(Minor(matrix, i));

        //    return det;
        //}

        //public static int[][] Minor(int[][] matrix, int pos)
        //{
        //    int[][] minor = new int[matrix.Length - 1][];
        //    for (int i = 0; i < minor.Length; i++)
        //        minor[i] = new int[minor.Length];

        //    for (int i = 1; i < matrix.Length; i++)
        //    {
        //        for (int j = 0; j < pos; j++)
        //            minor[i - 1][j] = matrix[i][j];
        //        for (int j = pos + 1; j < matrix.Length; j++)
        //            minor[i - 1][j - 1] = matrix[i][j];
        //    }
        //    return minor;
    }
}
