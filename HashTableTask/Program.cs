namespace HashTableTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Немного примеров работы класса HashTable:");
        Console.WriteLine();
        Console.Write("Создадим нашу коллекцию, заполним и отобразим её:");

        MyHashTable<string> strings1 = new MyHashTable<string>();
        strings1.Add("a");
        strings1.Add("b");
        strings1.Add("c");
        strings1.Add("d");
        strings1.Add("e");
        strings1.Add("f");
        strings1.Add("a");
        strings1.Add("a");
        strings1.Add("a");
        Console.WriteLine(strings1);
        Console.WriteLine();

        Console.WriteLine("Скопируем нашу коллекцию в массив");
        string[] stringsArray = new string[strings1.Count];
        strings1.CopyTo(stringsArray, 0);
        Console.WriteLine(string.Join(", ", stringsArray));
        Console.WriteLine();

        Console.WriteLine($"Удаляем 'e': {strings1.Remove("e")}, кол-во элементов: {strings1.Count}," +
            $" проверим наличие 'f': {strings1.Contains("f")}");

        strings1.Clear();
        Console.WriteLine($"Очистим нашу коллекцию: {strings1} ");
    }
}
