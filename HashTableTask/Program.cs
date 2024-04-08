namespace HashTableTask;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Немного примеров работы класса HashTable:");
        Console.WriteLine();
        Console.Write("Создадим нашу коллекцию, заполним и отобразим её:");

        SimpleHashTable<string> strings1 = new SimpleHashTable<string>
        {
            "a",
            "b",
            "c",
            "d",
            null!,
            "e",
            "f",
            "a",
            "a",
            "a",
        };

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
