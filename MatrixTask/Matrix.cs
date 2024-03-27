using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public int RowsAmount => _rows.Length;

    public int ColumnsAmount => _rows[0].GetSize();

    public Matrix(int rowsAmount, int columnsAmount)
    {
        ValidateInputDataParameters(rowsAmount, columnsAmount);

        _rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            _rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix matrix)
    {
        _rows = new Vector[matrix.ColumnsAmount];

        for (int i = 0; i < RowsAmount; i++)
        {
            _rows[i] = new Vector(matrix._rows[i]);
        }
    }

    public Matrix(double[,] array)
    {
        int rowsAmount = array.GetLength(0);
        int columnsAmount = array.GetLength(1);

        ValidateInputDataParameters(rowsAmount, columnsAmount);

        _rows = new Vector[array.GetLength(0)];

        for (int i = 0; i < rowsAmount; i++)
        {
            Vector newRow = new(rowsAmount);

            for (int j = 0; j < columnsAmount; j++)
            {
                newRow[j] = array[i, j];
            }

            _rows[i] = newRow;
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(vectors.Length), $"Array rows amount must be >= 0, current amount: {vectors.Length}");
        }

        int maxColumnsAmount = 0;

        foreach (var vector in vectors)
        {
            if (vector.GetSize() > maxColumnsAmount)
            {
                maxColumnsAmount = vector.GetSize();
            }
        }

        _rows = new Vector[vectors.Length];

        for (int i = 0; i < RowsAmount; i++)
        {
            _rows[i] = new Vector(maxColumnsAmount, vectors[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        ValidateMatricesParameters(matrix1, matrix2);

        Matrix resultMatrix = new(matrix1);
        resultMatrix.Add(matrix2);

        return resultMatrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        ValidateMatricesParameters(matrix1, matrix2);

        Matrix resultMatrix = new Matrix(matrix1);
        resultMatrix.Subtract(matrix2);

        return resultMatrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsAmount != matrix2.RowsAmount)
        {
            throw new ArgumentException($"The number of columns in the first matrix must be equal to the number of rows in the second matrix.{Environment.NewLine}" +
                $"First matrix columns, second matrix rows amount: {matrix1.ColumnsAmount}; {matrix2.RowsAmount}");
        }

        int resultRowsAmount = matrix1.RowsAmount;
        int resultColumnsAmount = matrix2.ColumnsAmount;
        Matrix resultMatrix = new Matrix(resultRowsAmount, resultRowsAmount);

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
        ValidateIndex(index, RowsAmount);

        return new Vector(_rows[index]);
    }

    public Vector SetRow(int index, Vector vector)
    {
        ValidateIndex(index, RowsAmount);

        if (vector.GetSize() > ColumnsAmount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector.GetSize), $"Vector size must be equal to matrix column amount, current size: {vector.GetSize}");
        }

        return _rows[index] = new Vector(vector);
    }

    public Vector GetColumn(int index)
    {
        ValidateIndex(index, ColumnsAmount);

        Vector result = new(ColumnsAmount);

        for (int i = 0; i < ColumnsAmount; i++)
        {
            result[i] = _rows[i][index];
        }

        return result;
    }

    public void Add(Matrix matrix)
    {
        ValidateMatricesParameters(this, matrix);

        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].Add(matrix._rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        ValidateMatricesParameters(this, matrix);

        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector vector in _rows)      // А это нормально, что я через итератор изменяю коллекцию?
        {
            vector.MultiplyByScalar(scalar);
        }
    }

    public Vector MultiplyByVector(Vector vector)
    {
        int columnsAmount = ColumnsAmount;

        if (columnsAmount != vector.GetSize())
        {
            throw new ArgumentException($"Matrix row and vector must be of the same size. " +
                $"Current vector size: {vector.GetSize()}, current row size {columnsAmount}", nameof(columnsAmount));
        }

        Vector result = new(columnsAmount);

        for (int i = 0; i < columnsAmount; i++)
        {
            result[i] = Vector.GetScalarProduct(vector, _rows[i]);
        }

        return result;
    }

    public void Transpose()
    {
        ValidateInputDataParameters(this);

        Vector[] newRows = new Vector[ColumnsAmount];

        for (int i = 0; i < _rows.Length; i++)
        {
            newRows[i] = GetColumn(i);
        }

        _rows = newRows;
    }

    public double GetDeterminant()
    {
        if (RowsAmount != ColumnsAmount)
        {
            throw new ArgumentException($"Matrix must be square. Current rows and columns amount: {RowsAmount}; {ColumnsAmount}");
        }

        if (_rows.Length == 1)
        {
            return _rows[0][0];
        }

        if (_rows.Length == 2)
        {
            return _rows[0][0] * _rows[1][1] - _rows[1][0] * _rows[0][1];
        }

        double determinant = 0;

        for (int i = 0; i < _rows.Length; i++)
        {
            Matrix minor = GetMinor(i);
            determinant += Math.Pow(-1, i) * _rows[i][0] * minor.GetDeterminant();
        }

        return determinant;
    }

    private static void ValidateMatricesParameters(Matrix matrix1, Matrix matrix2)
    {
        ValidateInputDataParameters(matrix1.RowsAmount, matrix1.ColumnsAmount);
        ValidateInputDataParameters(matrix2.RowsAmount, matrix2.ColumnsAmount);

        if (matrix1.RowsAmount != matrix2.RowsAmount && matrix1.ColumnsAmount != matrix2.ColumnsAmount)
        {
            throw new ArgumentException($"Matrices must be same size. First matrix rows and columns amount: {matrix1.RowsAmount} {matrix1.ColumnsAmount}; " +
                $"Second matrix rows and columns amount: {matrix2.RowsAmount} {matrix2.ColumnsAmount}");
        }
    }

    private static void ValidateIndex(int index, int matrixBoundary)
    {
        if (index < 0 || index >= matrixBoundary)
        {
            throw new IndexOutOfRangeException($"Index must be in matrix range: >= 0 and < {matrixBoundary}; index = {index}");
        }
    }

    private static void ValidateInputDataParameters(Matrix matrix) =>
    ValidateInputDataParameters(matrix.RowsAmount, matrix.ColumnsAmount);

    private static void ValidateInputDataParameters(int rowsAmount, int columnsAmount)
    {
        if (rowsAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowsAmount), $"Array rows amount must be >= 0, current amount: {rowsAmount}");
        }

        if (columnsAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnsAmount), $"Array columns amount must be >= 0, current amount: {columnsAmount}");
        }
    }

    private Matrix GetMinor(int position)
    {
        int minorRowsAmount = RowsAmount - 1;
        Matrix minor = new(minorRowsAmount, minorRowsAmount);

        for (int i = 1; i < RowsAmount; i++)
        {
            for (int j = 0; j < position; j++)
            {
                minor._rows[i - 1][j] = _rows[i][j];
            }

            for (int j = position + 1; j < RowsAmount; j++)
            {
                minor._rows[i - 1][j - 1] = _rows[i][j];
            }
        }

        return minor;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        int length = _rows.Length - 1;
        stringBuilder.Append('{');

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(_rows[i]);
            stringBuilder.Append(", ");
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

        if (RowsAmount != matrix.RowsAmount)
        {
            return false;
        }

        for (int i = 0; i < RowsAmount; i++)
        {
            if (_rows[i] != matrix._rows[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        int prime = 7;
        int hash = 1;

        foreach (Vector row in _rows)
        {
            hash = prime * hash + row.GetHashCode();
        }

        return hash;
    }
}