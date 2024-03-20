using VectorTask;

namespace MatrixTask;

internal class Program
{

// TODO Доделать проклятый определитель.
  

    
    static void Main(string[] args)
    {
        Console.WriteLine("Немного примеров работы класса Matrix, который описывает тензоры.");
        Console.WriteLine("Создадим новый пустой тензор размером 5 отобразим его и проверим его размер:");
        Matrix matrix1 = new Matrix(5, 5);
        Console.WriteLine(matrix1);
        Console.WriteLine(matrix1.GetSize());
        Console.WriteLine();

        Console.WriteLine("Инициализируем тензор через массив вещественных чисел и массив векторов и отобразим это:");
        Matrix matrix2 = new Matrix(new double[,] { { 10, 11, 12 }, { 120, 131, 112 }, { 1, 2, 3 } });
        Console.WriteLine(matrix2);

        Vector vector1 = new Vector(new double[] { 1, 2, 3 });
        Vector vector2 = new Vector(new double[] { 4, 5, 6 });
        Vector vector3 = new Vector(new double[] { 7, 8, 9 });
        Vector[] vectorArray = { vector1, vector2, vector3 };

        Matrix matrix3 = new Matrix(vectorArray);
        Console.WriteLine(matrix3);
        Console.WriteLine();

        Console.WriteLine("Поменяем первую строку, отобразим первую строку и столбец:");
        matrix3.SetVectorRow(0, vector3);
        Console.WriteLine(matrix3.GetVectorRow(0) + " " + matrix3.GetVectorColumn(0));
        Console.WriteLine();

        Console.WriteLine("Проверим сложение, вычитание, умножение на скаляр, вектор и транспонирование:");
        matrix3.Add(matrix2);
        Console.WriteLine(matrix3);
        matrix3.Subtract(matrix2);
        Console.WriteLine(matrix3);
        matrix3.MultiplyByScalar(6);
        Console.WriteLine(matrix3);
        vector3 = matrix3.MultiplyByVector(vector1);
        Console.WriteLine(vector3);
        matrix3.Transpose();
        Console.WriteLine(matrix3);
        Console.WriteLine();

        Console.WriteLine("Проверим статические методы сложения, вычитания и произведение:");
        Matrix matrix4 = new Matrix(3, 3);
        matrix4 = Matrix.GetSum(matrix2, matrix3);
        Console.WriteLine(matrix4);
        matrix4 = Matrix.GetDifference(matrix2, matrix3);
        Console.WriteLine(matrix4);
        matrix4 = Matrix.GetProduct(matrix2, matrix3);
        Console.WriteLine(matrix4);
    }
}
