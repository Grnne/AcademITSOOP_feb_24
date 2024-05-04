namespace GraphTask;

public class Graph
{
    private readonly int[,] _matrix;

    private readonly int _size;

    public Graph(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException($"Matrix must be square. Matrix rows amount = {matrix.GetLength(0)}, columns amount = {matrix.GetLength(1)}", nameof(matrix));
        }

        _matrix = matrix;
        _size = matrix.GetLength(0);
    }

    public void TraverseBreadthFirst(Action<int> action)
    {
        bool[] visited = new bool[_size];
        Queue<int> queue = new();

        for (int i = 0; i < _size; i++)
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

                for (int j = 0; j < _size; j++)
                {
                    if (!visited[i] && _matrix[currentVertex, i] != 0)
                    {
                        queue.Enqueue(j);
                    }
                }

                action.Invoke(currentVertex);
                visited[currentVertex] = true;
            }
        }
    }

    public void TraverseDepthFirst(Action<int> action)
    {
        bool[] visited = new bool[_size];
        Stack<int> stack = new();

        for (int i = 0; i < _size; i++)
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

                for (int j = _size - 1; j >= 0; j--)
                {
                    if (!visited[j] && _matrix[currentVertex, j] != 0)
                    {
                        stack.Push(j);
                    }
                }

                action.Invoke(currentVertex);
                visited[currentVertex] = true;
            }
        }
    }

    public void TraverseDepthFirstRecursive(Action<int> action)
    {
        bool[] visited = new bool[_size];

        for (int i = 0; i < _size; i++)
        {
            TraverseDepthFirstRecursive(action, visited, i);
        }
    }

    private void TraverseDepthFirstRecursive(Action<int> action, bool[] visited, int currentVertex)
    {
        if (visited[currentVertex])
        {
            return;
        }

        action.Invoke(currentVertex);
        visited[currentVertex] = true;

        for (int i = 0; i < _size; i++)
        {
            if (!visited[i] && _matrix[currentVertex, i] != 0)
            {
                TraverseDepthFirstRecursive(action, visited, i);
            }
        }
    }
}