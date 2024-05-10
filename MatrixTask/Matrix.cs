using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public int RowsAmount => _rows.Length;

    public int ColumnsAmount => _rows[0].Size;

    public Matrix(int rowsAmount, int columnsAmount)
    {
        CheckMatrixDimensions(rowsAmount, columnsAmount);

        _rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            _rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix matrix)
    {
        _rows = new Vector[matrix.RowsAmount];

        for (int i = 0; i < RowsAmount; i++)
        {
            _rows[i] = new Vector(matrix._rows[i]);
        }
    }

    public Matrix(double[,] array)
    {
        int rowsAmount = array.GetLength(0);
        int columnsAmount = array.GetLength(1);

        CheckMatrixDimensions(rowsAmount, columnsAmount);

        _rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            Vector row = new(columnsAmount);

            for (int j = 0; j < columnsAmount; j++)
            {
                row[j] = array[i, j];
            }

            _rows[i] = row;
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(vectors), $"Matrix rows amount must be greater then 0, current amount: {vectors.Length}");
        }

        int maxColumnsAmount = 0;

        foreach (Vector vector in vectors)
        {
            maxColumnsAmount = Math.Max(vector.Size, maxColumnsAmount);
        }

        _rows = new Vector[vectors.Length];

        for (int i = 0; i < RowsAmount; i++)
        {
            _rows[i] = new Vector(maxColumnsAmount);
            _rows[i].Add(vectors[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        CheckMatricesDimensionsEquality(matrix1, matrix2);

        Matrix resultMatrix = new(matrix1);
        resultMatrix.Add(matrix2);

        return resultMatrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        CheckMatricesDimensionsEquality(matrix1, matrix2);

        Matrix resultMatrix = new(matrix1);
        resultMatrix.Subtract(matrix2);

        return resultMatrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsAmount != matrix2.RowsAmount)
        {
            throw new ArgumentException($"The columns amount in the first matrix: {matrix1.ColumnsAmount} must be equal to the rows amount: {matrix2.RowsAmount} in the second matrix.");
        }

        int resultRowsAmount = matrix1.RowsAmount;
        int resultColumnsAmount = matrix2.ColumnsAmount;
        Matrix resultMatrix = new Matrix(resultRowsAmount, resultColumnsAmount);

        for (int i = 0; i < resultRowsAmount; i++)
        {
            for (int j = 0; j < resultColumnsAmount; j++)
            {
                resultMatrix._rows[i][j] = Vector.GetScalarProduct(matrix1._rows[i], matrix2.GetColumn(j));
            }
        }

        return resultMatrix;
    }

    public Vector GetRow(int index)
    {
        CheckIndex(index, RowsAmount);

        return new Vector(_rows[index]);
    }

    public void SetRow(int index, Vector vector)
    {
        CheckIndex(index, RowsAmount);

        if (vector.Size != ColumnsAmount)
        {
            throw new ArgumentException($"Vector size: {vector.Size} must be equal to matrix columns amount: {ColumnsAmount}", nameof(vector));
        }

        _rows[index] = new Vector(vector);
    }

    public Vector GetColumn(int index)
    {
        CheckIndex(index, ColumnsAmount);

        Vector column = new(RowsAmount);

        for (int i = 0; i < RowsAmount; i++)
        {
            column[i] = _rows[i][index];
        }

        return column;
    }

    public void Add(Matrix matrix)
    {
        CheckMatricesDimensionsEquality(this, matrix);

        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].Add(matrix._rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        CheckMatricesDimensionsEquality(this, matrix);

        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in _rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    public Vector MultiplyByVector(Vector vector)
    {
        if (ColumnsAmount != vector.Size)
        {
            throw new ArgumentException("Matrix row and vector must be of the same size. " +
                $"Current vector size: {vector.Size}, current row size {ColumnsAmount}", nameof(vector));
        }

        Vector resultVector = new(RowsAmount);

        for (int i = 0; i < RowsAmount; i++)
        {
            resultVector[i] = Vector.GetScalarProduct(_rows[i], vector);
        }

        return resultVector;
    }

    public void Transpose()
    {
        Vector[] newRows = new Vector[ColumnsAmount];

        for (int i = 0; i < ColumnsAmount; i++)
        {
            newRows[i] = GetColumn(i);
        }

        _rows = newRows;
    }

    public double GetDeterminant()
    {
        if (ColumnsAmount != RowsAmount)
        {
            throw new InvalidOperationException($"The matrix must be square. Columns amount: {ColumnsAmount} must be equal to the rows amount: {RowsAmount}");
        }   

        int size = ColumnsAmount;

        double[,] tempMatrix = new double[size, size]; // Jagged массив был бы удобнее

        for (int i = 0; i < size; i++)
        {
            Vector row = GetRow(i);

            for (int j = 0; j < size; j++)
            {
                tempMatrix[i, j] = row[j];
            }
        }

        // For 1 dimension matrix
        if (size == 1)
        {
            return tempMatrix[0, 0];
        }

        // For 2 dimension matrix
        if (size == 2)
        {
            return tempMatrix[0, 0] * tempMatrix[1, 1] - tempMatrix[0, 1] * tempMatrix[1, 0];
        }

        // For 3 dimension matrix
        if (size == 3)
        {
            return tempMatrix[0, 0] * tempMatrix[1, 1] * tempMatrix[2, 2]
                + tempMatrix[0, 1] * tempMatrix[1, 2] * tempMatrix[2, 0]
                + tempMatrix[0, 2] * tempMatrix[1, 0] * tempMatrix[2, 1]
                - tempMatrix[0, 2] * tempMatrix[1, 1] * tempMatrix[2, 0]
                - tempMatrix[0, 0] * tempMatrix[1, 2] * tempMatrix[2, 1]
                - tempMatrix[0, 1] * tempMatrix[1, 0] * tempMatrix[2, 2];
        }

        // Making upper triangular matrix by swapping, multiplying and subtracting
        int determinantCoefficient = 1;
        double epsilon = 0.1e-10f;
        int maxRowIndex = size;

        for (int i = 0; i < size - 1; i++)
        {
            int rowIndex = i;
            maxRowIndex -= i;

            if (Math.Abs(tempMatrix[rowIndex, i]) <= epsilon) // Rearrangements
            {
                while (Math.Abs(tempMatrix[rowIndex, i]) <= epsilon)
                {
                    if (rowIndex == maxRowIndex)
                    {
                        return 0; // If full column is zero, or any element of main diagonal is 0, also must protect from zero division
                    }

                    rowIndex++;
                }

                double[] tempRow = GetRowFromTempMatrix(rowIndex);
                SetRowToTempMatrix(rowIndex, GetRowFromTempMatrix(i));
                SetRowToTempMatrix(i, tempRow);
                determinantCoefficient *= -1;
            }

            for (int j = i + 1; j < size; j++) // Multiplying and subtracting
            {
                if (Math.Abs(tempMatrix[j, i]) > epsilon)
                {
                    double coefficientNumerator = tempMatrix[j, i];
                    double coefficientDenominator = tempMatrix[i, i];

                    for (int k = 0; k < size; k++)
                    {
                        tempMatrix[j, k] -= tempMatrix[i, k] * coefficientNumerator / coefficientDenominator;
                    }
                }
            }
        }

        double determinant = 1;

        for (int i = 0; i < size; i++)
        {
            determinant *= tempMatrix[i, i];
        }

        return determinant * determinantCoefficient;

        double[] GetRowFromTempMatrix(int index) => Enumerable.Range(0, size).Select(x => tempMatrix[index, x]).ToArray();

        void SetRowToTempMatrix(int index, double[] row)
        {
            for (int i = 0; i < size; i++)
            {
                tempMatrix[index, i] = row[i];
            }
        }
    }

    private static void CheckIndex(int index, int indexUpperLimit)
    {
        if (index < 0 || index >= indexUpperLimit)
        {
            throw new IndexOutOfRangeException($"Index must be in matrix range: >= 0 and < {indexUpperLimit}; index = {index}");
        }
    }

    private static void CheckMatrixDimensions(int rowsAmount, int columnsAmount)
    {
        if (rowsAmount <= 0)
        {
            throw new InvalidOperationException($"Matrix rows amount: {rowsAmount} must be greater than 0");
        }

        if (columnsAmount <= 0)
        {
            throw new InvalidOperationException($"Matrix columns amount: {columnsAmount} must be greater than 0");
        }
    }

    private static void CheckMatricesDimensionsEquality(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.RowsAmount != matrix2.RowsAmount || matrix1.ColumnsAmount != matrix2.ColumnsAmount)
        {
            throw new ArgumentException($"Matrices must have same dimensions. First matrix rows amount: {matrix1.RowsAmount}; columns amount: {matrix1.ColumnsAmount}" +
                $" Second matrix rows amount: {matrix2.RowsAmount}; columns amount: {matrix2.ColumnsAmount}");
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append('{');
        int maxIndex = _rows.Length - 1;

        for (int i = 0; i < maxIndex; i++)
        {
            stringBuilder.Append(_rows[i]).Append(", ");
        }

        stringBuilder.Append(_rows[^1]);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        Matrix matrix = (Matrix)obj;

        if (RowsAmount != matrix.RowsAmount || ColumnsAmount != matrix.ColumnsAmount)
        {
            return false;
        }

        for (int i = 0; i < RowsAmount; i++)
        {
            if (!_rows[i].Equals(matrix._rows[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        int prime = 23;
        int hash = 1;

        foreach (Vector row in _rows)
        {
            hash = prime * hash + row.GetHashCode();
        }

        return hash;
    }
}