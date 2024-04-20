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
            throw new ArgumentOutOfRangeException(nameof(vectors), $"Matrix rows amount must be >= 0, current amount: {vectors.Length}");
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

        Matrix resultMatrix = new Matrix(matrix1);
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
            throw new ArgumentOutOfRangeException(nameof(vector), $"Vector size: {vector.Size} must be equal to matrix columns amount: {ColumnsAmount}");
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
        int size = ColumnsAmount;

        // For 2 dimension matrix
        if (size == 2)
        {
            return GetColumn(0)[0] * GetColumn(1)[1]
                - GetColumn(0)[1] * GetColumn(1)[0];
        }

        // For 3 dimension matrix
        if (size == 3)
        {
            return GetColumn(0)[0] * GetColumn(1)[1] * GetColumn(2)[2]
                + GetColumn(0)[1] * GetColumn(1)[2] * GetColumn(2)[0]
                + GetColumn(0)[2] * GetColumn(1)[0] * GetColumn(2)[1]
                - GetColumn(0)[2] * GetColumn(1)[1] * GetColumn(2)[0]
                - GetColumn(0)[0] * GetColumn(1)[2] * GetColumn(2)[1]
                - GetColumn(0)[1] * GetColumn(1)[0] * GetColumn(2)[2];
        }

        // Swap and modifying determinant coefficient if matrix[0][0] = 0, return if whole column is 0
        // Нужно сделать аналогичный метод для каждого столбца, т.к. сейчас будет выдавать ошибки, если будет деление на ноль
        // Стоит ли оставить метод тут, для оптимизации в случае пустого первого столбца?
        Vector tempColumn = GetColumn(0);
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

            Vector tempRow = GetRow(count);
            SetRow(count, GetRow(0));
            SetRow(0, tempRow);
            determinantCoefficient *= -1;
        }

        // Making upper triangular matrix by multiplying and subtracting
        // Нужно как-то сделать, чтоб из-за округления значения близкие к 0 после вычитания занулялись
        // и чтоб значения в периоде адекватно округлялись.
        // Сделать вместо коэффициента умножение каждого столбца на текущую цифру противоположного?
        // Всё равно, если получится число в периоде в диагонали, будет большая погрешность в определителе

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (GetRow(j)[i] != 0)
                {
                    Vector multipliedRow = new(GetRow(i));
                    double multiplyCoefficient = Math.Round(GetRow(j)[i] / multipliedRow[i], 8, MidpointRounding.AwayFromZero);
                    multipliedRow.MultiplyByScalar(multiplyCoefficient);

                    for (int k = 0; k < size; k++)
                    {
                        multipliedRow[k] = Math.Round(multipliedRow[k], 8, MidpointRounding.AwayFromZero);
                    }

                    Vector processedRow = GetRow(j);

                    for (int k = 0; k < size; k++)
                    {
                        processedRow[k] = Math.Round(processedRow[k], 8, MidpointRounding.AwayFromZero);
                    }

                    processedRow.Subtract(multipliedRow);

                    for (int k = 0; k < size; k++)
                    {
                        processedRow[k] = Math.Round(processedRow[k], 8, MidpointRounding.ToZero);
                    }

                    SetRow(j, processedRow);
                }
            }
        }

        double determinant = 1;

        for (int i = 0; i < size; i++)
        {
            determinant *= GetRow(i)[i];
        }

        return determinant * determinantCoefficient;
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
            throw new ArgumentOutOfRangeException(nameof(rowsAmount), $"Matrix rows amount: {rowsAmount} must be greater than 0");
        }

        if (columnsAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnsAmount), $"Matrix columns amount: {columnsAmount} must be greater than 0");
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
        int maxIndex = _rows.Length - 1;
        stringBuilder.Append('{');

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