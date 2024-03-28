using System;

class GFG
{
    // Function that finds whether 
    // an element will be included
    // or not 
    static void includeElement(int[] a, int n, int sum)
    {
        for (int i = 0; i < n; i++)
        {
            // Check if the current element 
            // will be included or not 
            if ((sum - a[i]) >= 0)
            {
                sum = sum - a[i];
                Console.Write(a[i] + " ");
            }
        }
    }

    // Driver code 
    static void Main()
    {
        int[] test =
            [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
                14, 14, 14, 14, 14, 14, 14, 14,
                16, 16, 16, 16,
                32, 32];
        int[] test2 = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 14, 14, 14, 14, 14, 14, 16, 16, 16, 16, 32, 32};


        Console.WriteLine(test2.Sum());
    }
}