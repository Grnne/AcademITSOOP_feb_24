using MatrixTask;

namespace TrashCan;

internal class Program
{
    static void Main(string[] args)
    {
    
        LinkedList<string> list = new LinkedList<string>();
        list.ElementAt
        
        int[][] tensor1 =
        [
            [1, 2, 3, 4],
            [11, 12, 13, 14],
            [21, 22, 23, 24],
            [31, 32, 33, 34]
        ];

        int[][] tensor2 =
        [
            [1, 2],
            [3, 4]
        ];

        int det = Determinant(tensor1);
        Console.WriteLine(det);
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
        return minor;
    }
}
