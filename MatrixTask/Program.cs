﻿using VectorTask;

namespace MatrixTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Немного примеров работы класса Matrix.");
        Console.WriteLine("Создадим пустую матрицу 5х5:");
        Matrix matrix1 = new(5, 5);
        Console.WriteLine(matrix1);
        Console.WriteLine();

        Console.Write($"Посмотрим её размер: количество строк: {matrix1.RowsAmount}; количество столбцов: {matrix1.ColumnsAmount}");
        Console.WriteLine();

        Console.WriteLine("Инициализируем матрицу через массив вещественных чисел:");
        Matrix matrix2 = new(new double[,] { { 10, 11, 12 }, { 120, 131, 112 }, { 1, 2, 3 } });
        Console.WriteLine(matrix2);
        Console.WriteLine();

        Console.WriteLine("Инициализируем матрицу через массив векторов:");

        Vector vector1 = new(new double[] { 1, 2, 3 });
        Vector vector2 = new(new double[] { 4, 5, 6 });
        Vector vector3 = new(new double[] { 7, 8, 9 });
        Vector[] vectors =
        {
            vector1,
            vector2,
            vector3
        };

        Matrix matrix3 = new(vectors);
        Console.WriteLine(matrix3);
        Console.WriteLine();

        Console.WriteLine($"Поменяем первую строку на {vector3}, отобразим первую строку и столбец:");
        matrix3.SetRow(0, vector3);
        Console.WriteLine($"Строка: {matrix3.GetRow(0)}; столбец: {matrix3.GetColumn(0)}");
        Console.WriteLine();

        Console.WriteLine("Проверим сложение, вычитание, умножение на скаляр, вектор и транспонирование:");
        Console.WriteLine($"Сложим {matrix3} и {matrix2}");
        matrix3.Add(matrix2);
        Console.WriteLine($"Результат: {matrix3}");
        Console.WriteLine();

        Console.WriteLine($"Вычтем {matrix3} и {matrix2}");
        matrix3.Add(matrix2);
        Console.WriteLine($"Результат: {matrix3}");
        Console.WriteLine();

        Console.WriteLine($"Умножим {matrix3} на 6");
        matrix3.MultiplyByScalar(6);
        Console.WriteLine($"Результат: {matrix3}");
        Console.WriteLine();

        Console.WriteLine($"Умножим {matrix3} на вектор {vector1}");
        vector3 = matrix3.MultiplyByVector(vector1);
        Console.WriteLine($"Результат: {vector3}");
        Console.WriteLine();

        Console.WriteLine($"Транспонируем: {matrix3}");
        matrix3.Transpose();
        Console.WriteLine($"Результат: {matrix3}");
        Console.WriteLine();

        Console.WriteLine("Проверим статические методы сложения, вычитания и произведение:");

        Console.WriteLine($"Сложим {matrix2} и {matrix3}");
        Matrix matrix4 = Matrix.GetSum(matrix2, matrix3);
        Console.WriteLine($"Результат: {matrix4}");
        Console.WriteLine();

        Console.WriteLine($"Вычтем {matrix2} и {matrix3}");
        matrix4 = Matrix.GetDifference(matrix2, matrix3);
        Console.WriteLine($"Результат: {matrix4}");
        Console.WriteLine();

        Console.WriteLine($"Произведение {matrix2} и {matrix3}");
        Console.WriteLine($"Результат: {Matrix.GetProduct(matrix2, matrix3)}");
        Console.WriteLine();

        Matrix matrix5 = new(new double[,]
        {
            { 0, 0, 3, 4 },
            { 0, 0, 2, 3 },
            { 3, 1, 1, 0 },
            { 5, 0, 0, 0 }
        });

        Console.WriteLine($"Найдем определитель матрицы {matrix5}");
        Console.WriteLine($"Результат: {matrix5.GetDeterminant()}");
    }
}