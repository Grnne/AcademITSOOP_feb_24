namespace ListTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Проверим наш связный список");
        SinglyLinkedList<int> list1 = new() { 1, 3, 4, 5, 6, 1, 1, 8, 9 };

        Console.WriteLine("Отобразим список и его размер");
        Console.WriteLine(list1);
        Console.WriteLine(list1.Count);

        list1.RemoveFirst();
        Console.WriteLine($"Удалим 1й элемент и посмотрим новый первый элемент: {list1.GetFirst()}");
        list1.AddFirst(123123);
        Console.WriteLine($"Добавим новый 1 элемент и посмотрим его значение: {list1.GetFirst()}");

        list1.Add(5, 123);
        Console.WriteLine($"Поменяем значение по индексу 5 на 123 и отобразим: {list1[5]}");
        list1.RemoveAt(5);
        Console.WriteLine($"Удалим значение по индексу 5 отобразим результат: {list1[5]}");

        Console.WriteLine($"Удалим значение 9: {list1.Remove(9)} и отобразим результат: {list1}");

        list1.Reverse();
        Console.WriteLine($"Развернем список: {list1}");

        SinglyLinkedList<int> list2 = list1.Copy();

        Console.WriteLine($"Скопируем список: {list2}");
    }
}
