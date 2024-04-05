using ArrayListTask;

namespace TrashCan;

public static class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> ints = new ArrayList<int>(0);

        ints.Insert(0,4);

        Console.WriteLine(ints);

    }
}