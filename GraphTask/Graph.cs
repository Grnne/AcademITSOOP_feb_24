namespace GraphTask;

public class Graph
{
    public int[,] Matrix { get; private set; }

    public double[] Data { get; set; }

    public int Size { get; private set; }

    public Graph(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException($"Matrix must be square. Matrix rows amount = {matrix.GetLength(0)}, columns amount = {matrix.GetLength(1)}", nameof(matrix));
        }

        Matrix = matrix;
        Size = matrix.GetLength(0);
        Data = new double[Size];
    }

    public void TraverseBreadthFirst(Action<double> action)
    {
        bool[] visited = new bool[Size];
        Queue<int> queue = new();

        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();

            if (visited[currentNode])
            {
                continue;
            }

            action.Invoke(Data[currentNode]);

            for (int i = 0; i < Size; i++)
            {
                if (!visited[i] && Matrix[currentNode, i] == 1)
                {
                    queue.Enqueue(i);
                }
            }

            visited[currentNode] = true;
        }
    }

    public void TraverseDepthFirst(Action<double> action)
    {
        bool[] visited = new bool[Size];
        Stack<int> stack = new();

        stack.Push(0);

        while (stack.Count > 0)
        {
            int currentNode = stack.Pop();

            if (visited[currentNode])
            {
                continue;
            }

            action.Invoke(Data[currentNode]);

            for (int i = Size - 1; i >= 0; i--)
            {
                if (!visited[currentNode] && Matrix[currentNode, i] == 1)
                {
                    stack.Push(i);
                }
            }

            visited[currentNode] = true;
        }
    }

    public void TraverseDepthFirstRecursive(Action<double> action)
    {
        bool[] visited = new bool[Size];

        TraverseDepthFirstRecursive(action, visited, 0);
    }

    private void TraverseDepthFirstRecursive(Action<double> action, bool[] visited, int currentNode)
    {
        if (visited[currentNode])
        {
            return;
        }

        action.Invoke(Data[currentNode]);
        visited[currentNode] = true;

        for (int i = 0; i < Size; i++)
        {
            if (!visited[i] && Matrix[currentNode, i] == 1)
            {
                TraverseDepthFirstRecursive(action, visited, i);
            }
        }
    }
}
