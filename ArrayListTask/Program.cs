namespace ArrayListTask;

//TODO спросить как вывести через стринг_джоин только элементы в отображаемой области, и про прагма варнинг

internal class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>(); // Для сравнения методов c листом
        Console.WriteLine("Создадим наш лист, добавим элемент и посмотрим его длину");

        ArrayList<int> myList1 = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        
        Console.WriteLine(myList1);
        Console.WriteLine();

        Console.WriteLine("Длина до добавления элемента: " + myList1.Count);
        myList1.Add(100);
        Console.WriteLine("Длина после добавления элемента: " + myList1.Count);
        Console.WriteLine();

        Console.WriteLine("Вставим, удалим пару элементов разными способами");
        myList1.Add(3);
        myList1.Insert(0, 1000);
        myList1.Remove(3);
        myList1.RemoveAt(1);

        Console.WriteLine("В результате получилось: " + myList1);
        Console.WriteLine();

        Console.WriteLine($"Проверим Contains(1000): {myList1.Contains(1000)}, IndexOf(7): {myList1.IndexOf(7)} ");
        Console.WriteLine();

        Console.WriteLine("Проверим CopyTo, Clear и TrimExcess");

        int[] array = new int[30];

        myList1.CopyTo(array, 5);

        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine();

        myList1.Clear();
       
        Console.WriteLine(myList1);

        myList1.TrimExcess();

        Console.WriteLine(myList1);
    }
}
