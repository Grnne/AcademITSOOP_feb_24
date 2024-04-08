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
        ValidateMatrixSize(rowsAmount, columnsAmount);

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

        ValidateMatrixSize(rowsAmount, columnsAmount);

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
            throw new ArgumentException($"The columns amount in the first matrix: {matrix1.ColumnsAmount} must be equal to the rows amount: {matrix2.RowsAmount} in the second matrix.");
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

    public void SetRow(int index, Vector vector)
    {
        ValidateIndex(index, RowsAmount);

        if (vector.Size != ColumnsAmount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector), $"Vector size: {vector.Size} must be equal to matrix columns amount: {ColumnsAmount}");
        }

        _rows[index] = new Vector(vector);
    }

    public Vector GetColumn(int index)
    {
        ValidateIndex(index, RowsAmount);

        Vector column = new(RowsAmount);

        for (int i = 0; i < RowsAmount; i++)
        {
            column[i] = _rows[i][index];
        }

        return column;
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
        if (RowsAmount != ColumnsAmount)
        {
            throw new InvalidOperationException($"Matrix must be square. Current rows amount: {RowsAmount}; columns amount: {ColumnsAmount}");
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

    private static void ValidateIndex(int index, int upperIndexLimit)
    {
        if (index < 0 || index >= upperIndexLimit)
        {
            throw new IndexOutOfRangeException($"Index must be in matrix range: >= 0 and < {upperIndexLimit}; index = {index}");
        }
    }

    private static void ValidateMatrixSize(int rowsAmount, int columnsAmount)
    {
        if (rowsAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowsAmount), $"Matrix rows amount must be >= 0, current amount: {rowsAmount}");
        }

        if (columnsAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnsAmount), $"Matrix columns amount must be >= 0, current amount: {columnsAmount}");
        }
    }

    private Matrix GetMinor(int rowIndex)
    {
        int minorSize = RowsAmount - 1;
        Matrix minor = new(minorSize, minorSize);

        for (int i = 1; i < RowsAmount; i++)
        {
            for (int j = 0; j < rowIndex; j++)
            {
                minor._rows[i - 1][j] = _rows[i][j];
            }

            for (int j = rowIndex + 1; j < RowsAmount; j++)
            {
                minor._rows[i - 1][j - 1] = _rows[i][j];
            }
        }

        return minor;
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

        if (RowsAmount != matrix.RowsAmount)
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
        int prime = 21;
        int hash = 1;

        foreach (Vector row in _rows)
        {
            hash = prime * hash + row.GetHashCode();
        }

        return hash;
    }
}