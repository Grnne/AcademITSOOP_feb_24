using MatrixTask;
using VectorTask;

internal class Program
{
    private static void Main(string[] args)
    {
        


        Matrix matrix1 = new Matrix(new double[,]
        {
            {1, 2 },
            {4, 1}
        });



        Matrix matrix2 = new Matrix(new double[,]
        {
            {1, 2 ,10 },
            {4, 1,15},
            { 0,2,11}
        });

        Console.WriteLine($"Matrices must have same dimensions. First matrix rows amount: {matrix1.RowsAmount}; columns amount: {matrix1.ColumnsAmount} Second matrix rows amount: {matrix2.RowsAmount}; columns amount: {matrix2.ColumnsAmount}");

        Matrix matrix3 = new Matrix(new double[,]
        {
            {5, 2, 3, 4},
            {2, 0, 2, 3},
            {3, 5, 1, 0},
            {5, 1, 0, 0}
        });

        Console.WriteLine(matrix3);
        Console.WriteLine(GetDeterminant(matrix3));
    }

    public static double GetDeterminant(Matrix @this)
    {
        int size = @this.ColumnsAmount;

        // For 2 dimension matrix
        if (size == 2)
        {
            return @this.GetColumn(0)[0] * @this.GetColumn(1)[1]
                - @this.GetColumn(0)[1] * @this.GetColumn(1)[0];
        }

        // For 3 dimension matrix
        if (size == 3)
        {
            return @this.GetColumn(0)[0] * @this.GetColumn(1)[1] * @this.GetColumn(2)[2]
                + @this.GetColumn(0)[1] * @this.GetColumn(1)[2] * @this.GetColumn(2)[0]
                + @this.GetColumn(0)[2] * @this.GetColumn(1)[0] * @this.GetColumn(2)[1]
                - @this.GetColumn(0)[2] * @this.GetColumn(1)[1] * @this.GetColumn(2)[0]
                - @this.GetColumn(0)[0] * @this.GetColumn(1)[2] * @this.GetColumn(2)[1]
                - @this.GetColumn(0)[1] * @this.GetColumn(1)[0] * @this.GetColumn(2)[2];
        }

        // Swap and modifying determinant coefficient if matrix[0][0] = 0, return if whole column is 0
        Vector tempColumn = @this.GetColumn(0);
        int determinantCoefficient = 1;

        if (tempColumn[0] == 0)
        {
            int count = 0;

            while (tempColumn[count] == 0)
            {
                count++;

                if (count == size)
                {
                    return 0;
                }
            }

            Vector tempRow = @this.GetRow(count);
            @this.SetRow(count, @this.GetRow(0));
            @this.SetRow(0, tempRow);
            determinantCoefficient *= -1;
        }

        // Making upper triangular matrix by multiplying and subtracting

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (@this.GetRow(j)[i] != 0)
                {
                    Vector multiplyedRow = new(@this.GetRow(i));
                    double multiplyCoefficient = Math.Round(@this.GetRow(j)[i] / multiplyedRow[i], 2, MidpointRounding.AwayFromZero);
                    multiplyedRow.MultiplyByScalar(multiplyCoefficient);

                    for (int k = 0; k < size; k++)
                    {
                        multiplyedRow[k] = Math.Round(multiplyedRow[k], 2, MidpointRounding.AwayFromZero);
                    }

                    Vector processedRow = @this.GetRow(j);

                    for (int k = 0; k < size; k++)
                    {
                        processedRow[k] = Math.Round(processedRow[k], 2, MidpointRounding.AwayFromZero);
                    }

                    processedRow.Subtract(multiplyedRow);

                    for (int k = 0; k < size; k++)
                    {
                        processedRow[k] = Math.Round(processedRow[k], 2, MidpointRounding.ToZero);
                    }

                    @this.SetRow(j, processedRow);
                }
            }
        }

        double determinant = 1;

        for (int i = 0; i < size; i++)
        {
            determinant *= @this.GetRow(i)[i];
        }

        return determinant * determinantCoefficient;
    }
}