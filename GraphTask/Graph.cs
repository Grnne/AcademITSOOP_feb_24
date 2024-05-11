namespace GraphTask;

public class Graph
{
    private readonly int[,] _matrix;

    public int Size => _matrix.GetLength(0);

    public Graph(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException($"Matrix must be square. Matrix rows amount = {matrix.GetLength(0)}, columns amount = {matrix.GetLength(1)}", nameof(matrix));
        }

        _matrix = matrix;
    }

    public void TraverseBreadthFirst(Action<int> action)
    {
        bool[] visited = new bool[Size];
        Queue<int> queue = new();

        for (int i = 0; i < Size; i++)
        {
            if (visited[i])
            {
                continue;
            }

            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                if (visited[currentVertex])
                {
                    continue;
                }

                action.Invoke(currentVertex);
                visited[currentVertex] = true;

                for (int j = 0; j < Size; j++)
                {
                    if (!visited[j] && _matrix[currentVertex, j] != 0)
                    {
                        queue.Enqueue(j);
                    }
                }
            }
        }
    }

    public void TraverseDepthFirst(Action<int> action)
    {
        bool[] visited = new bool[Size];
        Stack<int> stack = new();

        for (int i = 0; i < Size; i++)
        {
            if (visited[i])
            {
                continue;
            }

            stack.Push(i);

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();

                if (visited[currentVertex])
                {
                    continue;
                }

                action.Invoke(currentVertex);
                visited[currentVertex] = true;

                for (int j = Size - 1; j >= 0; j--)
                {
                    if (!visited[j] && _matrix[currentVertex, j] != 0)
                    {
                        stack.Push(j);
                    }
                }
            }
        }
    }

    public void TraverseDepthFirstRecursive(Action<int> action)
    {
        bool[] visited = new bool[Size];

        for (int i = 0; i < Size; i++)
        {
            if (!visited[i])
            {
                TraverseDepthFirstRecursive(action, visited, i);
            }
        }
    }

    private void TraverseDepthFirstRecursive(Action<int> action, bool[] visited, int currentVertex)
    {
        action.Invoke(currentVertex);
        visited[currentVertex] = true;

        for (int i = 0; i < Size; i++)
        {
            if (!visited[i] && _matrix[currentVertex, i] != 0)
            {
                TraverseDepthFirstRecursive(action, visited, i);
            }
        }
    }
}