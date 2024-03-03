using VectorTask;

namespace MatrixTask;

public class Matrix
{
    public Vector[] Rows { get; set; }

    public Matrix(int rowsAmount, int columnsAmount)
    {
        Rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            Rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix incomingMatrix)
    {
        Rows = new Vector[incomingMatrix.Rows.Length];

        for (int i = 0; i < incomingMatrix.Rows.Length; i++)
        {
            Rows[i] = new Vector(incomingMatrix.Rows[i]);
        }
    }

    public Matrix(double[,] incomingMatrix)
    {
        Rows = new Vector[incomingMatrix.GetLength(0)];

        for (int i = 0; i < incomingMatrix.GetLength(0); i++)
        {
            Rows[i] = new Vector(Enumerable.Range(0, incomingMatrix.GetLength(0)).Select(x => incomingMatrix[x, i]).ToArray());
        }
    }

    public Matrix(Vector[] incomingMatrix)
    {
        Rows = new Vector[incomingMatrix.Length];

        for (int i = 0; i < incomingMatrix.Length; i++)
        {
            Rows[i] = new Vector(incomingMatrix[i]);
        }
    }

    public static void Add(Matrix matrix1, Matrix matrix2)
    { }

    public static void Subtract(Matrix matrix1, Matrix matrix2)
    { }

    public static void Multiply(Matrix matrix1, Matrix matrix2)
    { }


    public (int,int) GetSize()
    { return (0, 0); }

    public Vector GetVectorRow()
    { return new Vector(0); }

    public Vector SetVectorRow()
    { return new Vector(0); }

    public Vector GetVectorColumn()
    { return new Vector(0); }

    public void Transpose()
    { }

    public void MultiplyByScalar() //Возможно ScalarMultiply
    { }

    public double GetDeterminant()
    { 
        return 0;
    }

    public void Add()
    { }

    public void Subtract()
    { }

    public override string ToString()
    {
        return base.ToString();
    }
}