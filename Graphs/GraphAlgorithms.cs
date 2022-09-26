namespace Graphs;

public class GraphAlgorithms
{
	private static List<int>[] graph;
	private static bool[] visited;

	public static void Main()
	{
		graph = new List<int>[]
		{
			new List<int>{3, 6},
			new List<int>{2, 3, 4, 5, 6},
			new List<int>{1, 4, 5},
			new List<int>{0, 1, 5},
			new List<int>{1, 2, 6},
			new List<int>{1, 2, 3},
			new List<int>{0, 1, 4}
		};

		visited = new bool[graph.Length];

		for (int i = 0; i < graph.Length; i++)
		{
			BFS(i);
		}
	}

	private static void DFS(int node)
	{
		if (!visited[node])
		{
			visited[node] = true;

			foreach (var child in graph[node])
			{
				DFS(child);
			}

			Console.Write($"{node} ");
		}
	}

	private static void BFS(int node)
	{
		if (visited[node])
		{
			return;
		}

		var queue = new Queue<int>();
		queue.Enqueue(node);
		visited[node] = true;

		while (queue.Any())
		{
			var currentItem = queue.Dequeue();

			Console.Write($"{currentItem} ");
			foreach (var child in graph[currentItem])
			{
				if (!visited[child])
				{
					visited[child] = true;
					queue.Enqueue(child);
				}
			}
		}
	}
}