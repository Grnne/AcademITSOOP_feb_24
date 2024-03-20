using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] rows;

    public Matrix(int rowsAmount, int columnsAmount)
    {
        int minSize = Math.Min(rowsAmount, columnsAmount);

        if (minSize <= 0)
        {
            throw new ArgumentOutOfRangeException($"Must be more then zero matrix elements. Minimal dimension = {minSize}", nameof(minSize));
        }

        rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix incomingMatrix)
    {
        rows = new Vector[incomingMatrix.rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new Vector(incomingMatrix.rows[i]);
        }
    }

    public Matrix(double[,] incomingArray)
    {
        if (incomingArray.Length == 0)
        {
            throw new ArgumentOutOfRangeException($"Must be more then zero matrix elements. Minimal dimension = {incomingArray.Length}", nameof(incomingArray.Length));
        }

        rows = new Vector[incomingArray.GetLength(0)];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new Vector(Enumerable.Range(0, incomingArray.GetLength(1)).
                Select(x => incomingArray[i, x]).
                ToArray());
        }
    }

    public Matrix(Vector[] incomingArray)
    {
        if (incomingArray.Length == 0)
        {
            throw new ArgumentOutOfRangeException($"Must be more then zero matrix elements! Minimal dimension = {incomingArray.Length}", nameof(incomingArray.Length));
        }

        rows = new Vector[incomingArray.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new Vector(incomingArray[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.GetSize() != matrix2.GetSize())
        {
            throw new ArgumentException("Matrix must have same dimensions!");
        }

        Matrix resultMatrix = new Matrix(matrix1);
        resultMatrix.Add(matrix2);

        return resultMatrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.GetSize() != matrix2.GetSize())
        {
            throw new ArgumentException("Matrix must have same dimensions!");
        }

        Matrix resultMatrix = new Matrix(matrix1);
        resultMatrix.Subtract(matrix2);
        
        return resultMatrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.GetSize() != matrix2.GetSize())
        {
            throw new ArgumentException("Matrix must have same dimensions!");
        }

        int length = matrix1.rows.Length;
        Matrix resultMatrix = new Matrix(length,length);

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                resultMatrix.rows[i].SetComponent(j, Vector.GetScalarProduct(matrix1.rows[i], matrix2.GetVectorColumn(j)));
            }
        }

        return resultMatrix;
    }
    
    public (int, int) GetSize() => (rows[0].GetSize(), rows.Length);  // Я так понимаю, в лямбды исключения уже не вставить, надо переделывать?

    public Vector GetVectorRow(int index) => new Vector(rows[index]);

    public Vector SetVectorRow(int index, Vector vector) => rows[index] = new Vector(vector);

    public Vector GetVectorColumn(int index)
    {
        Vector result = new Vector(rows.Length);

        for (int i = 0; i < rows.Length; i++)
        {
            result.SetComponent(i, rows[i].GetComponent(index));
        }

        return result;
    }

    public void Add(Matrix matrix)
    {
        if (GetSize() != matrix.GetSize())
        {
            throw new ArgumentException("Matrices must be of the same dimension!");
        }

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].Add(matrix.rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (GetSize() != matrix.GetSize())
        {
            throw new ArgumentException("Matrices must be of the same dimension!");
        }

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].Subtract(matrix.rows[i]);
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].MultiplyByScalar(scalar);
        }
    }

    public Vector MultiplyByVector(Vector vector)
    {
        if (rows.Length != vector.GetSize()) 
        {
            throw new ArgumentException($"Matrix and vector must be of the same length!", nameof(rows.Length));
        }

        Vector result = new Vector(rows.Length);

        for (int i = 0; i < rows.Length; i++)
        {
            result.SetComponent(i, Vector.GetScalarProduct(vector, rows[i]));
        }

        return result;
    }

    public void Transpose()
    {
        if (GetSize().Item1 != GetSize().Item2)
        {
            throw new ArgumentException("Matrix must be square!");
        }

        Vector[] vectors = new Vector[rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            vectors[i] = GetVectorColumn(i);
        }

        rows = vectors;
    }

    public double GetDeterminant()
    {
        if (rows.Length == 1)
        {
            return rows[0].GetComponent(0);
        }

        if (rows.Length == 2)
        {
            return rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[1].GetComponent(0) * rows[0].GetComponent(1);
        }

        double determinant = 0;

        for (int i = 0; i < rows.Length; i++)
        {
            Matrix minor = GetMinor(i);
            determinant += Math.Pow(-1, i) * rows[0].GetComponent(i) * minor.GetDeterminant();
        }

        return determinant;
    }

    private Matrix GetMinor(int position)
    {
        Matrix minor = new Matrix(rows.Length - 1, rows.Length - 1);


        for (int i = 1; i < minor.rows.Length; i++)
        {
            for (int j = 0; j < position; j++)
            {
                minor.rows[i - 1].SetComponent(j, rows[i].GetComponent(j));
            }

            for (int j = position + 1; j < rows.Length; j++)
            {
                minor.rows[i - 1].SetComponent(j - 1, rows[i].GetComponent(j));
            }
        }

        return minor;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append('{');

        for (int i = 0; i < rows.Length - 1; i++)
        {
            stringBuilder.Append(rows[i]);
            stringBuilder.Append(", ");
        }

        stringBuilder.Append(rows[rows.Length - 1]);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }
}