using ArrayListTask;

namespace TrashCan;

public static class Program
{
    public static void Main(string[] args)
    {
        string temp = "";

        for (int i = 0; i < 5; i++)
        {
            temp += "собака ";
            Console.WriteLine(temp);
        }
    }
}