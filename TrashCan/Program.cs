using ArrayListTask;

namespace TrashCan;

public static class Program
{
    public static void Main(string[] args)
    {
        int[][] ints = new int[4][];
        ints[0] = [1, 2, 3, 4];
        ints[1] = [1, 5, 2, 5];
        ints[2] = [4, 3, -2, 10];
        ints[3] = [5, 2, 7, 4];


        Determinant(ints);

    }


    public static int Determinant(int[][] matrix)
    {
        int det = 0;
        if (matrix.Length != matrix[0].Length)
            return -1;
        if (matrix.Length == 1)
            return matrix[0][0];

        for (int i = 0; i < matrix.Length; i++)
            det += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(Minor(matrix, i));

        return det;
    }

    public static int[][] Minor(int[][] matrix, int pos)
    {
        int[][] minor = new int[matrix.Length - 1][];
        for (int i = 0; i < minor.Length; i++)
            minor[i] = new int[minor.Length];

        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 0; j < pos; j++)
                minor[i - 1][j] = matrix[i][j];
            for (int j = pos + 1; j < matrix.Length; j++)
                minor[i - 1][j - 1] = matrix[i][j];
        }
        Console.WriteLine();
        foreach (int[] row in minor)
        {
            Console.WriteLine(string.Join(", ",row));
        }
        Console.WriteLine();
        return minor;
    }
}