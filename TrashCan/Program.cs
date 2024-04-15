using ArrayListTask;

namespace TrashCan;

public static class Program
{
    public static void Main(string[] args)
    {
        int[][] ints = Pyramid(1);

        foreach (int[] i in ints)
        {
            Console.WriteLine("[" + string.Join(", ", i) + "]");
        }


    }

    public static int[][] Pyramid(int n)
    {
        int[][] array = new int[n][];

        if (n == 0)
        {
            return array;
        }
        else
        {

            for (int i = 0; i < n; i++)
            {
                array[i] = new int[i + 1];

                for (int j = 0; j < i + 1; j++)
                {
                    array[i][j] = 1;
                }
            }
        }

        return array;
    }
}