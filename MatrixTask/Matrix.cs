using VectorTask;

namespace MatrixTask;

public class Matrix
{
    public Vector[] Rows { get; set; }

    public Matrix(int rowsAmount, int columnsAmount)
    {
        if (rowsAmount <= 0 || columnsAmount <= 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero matrix elements.", nameof(rowsAmount));
        }

        Rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            Rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix incomingMatrix)
    {
        Rows = new Vector[incomingMatrix.Rows.Length];

        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i] = new Vector(incomingMatrix.Rows[i]);
        }
    }

    public Matrix(double[,] incomingArray)
    {
        if (incomingArray.Length == 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero matrix elements.");
        }

        Rows = new Vector[incomingArray.GetLength(0)];

        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i] = new Vector(Enumerable.Range(0, incomingArray.GetLength(1)).
                Select(x => incomingArray[i, x]).
                ToArray());
        }
    }

    public Matrix(Vector[] incomingArray)
    {
        if (incomingArray.Length == 0)
        {
            throw new ArgumentOutOfRangeException("Must be more then zero matrix elements.");
        }

        Rows = new Vector[incomingArray.Length];

        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i] = new Vector(incomingArray[i]);
        }
    }

    //public static void Add(Matrix matrix1, Matrix matrix2)
    //{ }

    //public static void Subtract(Matrix matrix1, Matrix matrix2)
    //{ }

    //public static void Multiply(Matrix matrix1, Matrix matrix2)
    //{ }

    public (int, int) GetSize() => (Rows[0].GetSize(), Rows.Length);

    public Vector GetVectorRow(int index) => new Vector(Rows[index]);

    public Vector SetVectorRow(int index, Vector vector) => Rows[index] = new Vector(vector);


    public Vector GetVectorColumn(int index)
    {
        Vector result = new Vector(Rows.Length);

        for (int i = 0; i < Rows.Length; i++)
        {
            result.SetComponent(i, Rows[i].GetComponent(index));
        }

        return result;
    }

    public void Add(Matrix matrix)
    {
        if (GetSize() == matrix.GetSize())
        {
            throw new ArgumentException("Matrices must be of the same dimension!");
        }

        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i].Add(matrix.Rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (GetSize() == matrix.GetSize())
        {
            throw new ArgumentException("Matrices must be of the same dimension!");
        }

        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i].Subtract(matrix.Rows[i]);
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < Rows.Length; i++)
        {
            Rows[i].MultiplyByScalar(scalar);
        }
    }

    public Vector MultiplyByVector(Vector vector)
    {
        Vector result = new Vector(Rows.Length);

        for (int i = 0; i < Rows.Length; i++)
        {
            result.SetComponent(i, Vector.GetScalarProduct(vector, Rows[i]));
        }

        return result;
    }

    public void Transpose()
    {
        Vector[] vectors = new Vector[Rows.Length];

        for (int i = 0; i < Rows.Length; i++)
        {
            vectors[i] = GetVectorColumn(i);
        }

        Rows = vectors;
    }

    public double GetDeterminant()
    {
        return 0;
    }

    public override string ToString() => "{" + string.Join(", ", (IEnumerable<Vector>)Rows) + "}";


}