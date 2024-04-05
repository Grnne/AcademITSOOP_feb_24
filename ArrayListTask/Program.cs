namespace ArrayListTask;

//TODO спросить как вывести через стринг_джоин только элементы в отображаемой области, и про прагма варнинг

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Создадим наш лист, добавим элемент и посмотрим его длину");
        ArrayList<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine(list);
        Console.WriteLine();

        Console.WriteLine("Длина до добавления элемента: " + list.Count);
        list.Add(100);
        Console.WriteLine("Длина после добавления элемента: " + list.Count);
        Console.WriteLine();

        Console.WriteLine("Вставим, удалим пару элементов разными способами");
        list.Add(3);
        list.Insert(0, 1000);
        list.Remove(3);
        list.RemoveAt(1);
        Console.WriteLine("В результате получилось: " + list);
        Console.WriteLine();

        Console.WriteLine($"Проверим Contains(1000): {list.Contains(1000)}, IndexOf(7): {list.IndexOf(7)}");
        Console.WriteLine();

        Console.WriteLine("Проверим CopyTo, TrimExcess и Clear");
        Console.WriteLine();

        int[] array = new int[16];
        list.CopyTo(array, 5);

        Console.WriteLine("Скопированный массив:");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine();

        Console.WriteLine("Вместимость до Trim: " + list.Capacity);
        list.TrimExcess();
        Console.WriteLine("Вместимость после Trim: " + list.Capacity);
        Console.WriteLine();

        list.Clear();
        Console.WriteLine("Лист после очистки: " + list);
    }
}
