namespace Dijkstra_sAlgorithm;

public class Program
{
	public static void Main()
	{
		var graph = new List<Edge>
		{
			new Edge{ First = 2, Second = 4, Weight = 2 },
			new Edge{ First = 1, Second = 4, Weight = 9 },
			new Edge{ First = 3, Second = 5, Weight = 7 },
			new Edge{ First = 5, Second = 5, Weight = 8 },
			new Edge{ First = 8, Second = 9, Weight = 7 },
			new Edge{ First = 1, Second = 2, Weight = 4 },
			new Edge{ First = 5, Second = 6, Weight = 12 },
			new Edge{ First = 7, Second = 8, Weight = 8 },
			new Edge{ First = 7, Second = 9, Weight = 10 },
			new Edge{ First = 1, Second = 3, Weight = 5 },
			new Edge{ First = 3, Second = 4, Weight = 20 }
		};

		var nodeToEdges = new Dictionary<int, List<Edge>>();

		var nodes = graph
			.Select(e => e.First)
			.Union(graph.Select(e => e.Second))
			.Distinct()
			.OrderBy(e => e)
			.ToHashSet();

		foreach (var edge in graph)
		{
			if (!nodeToEdges.ContainsKey(edge.First))
			{
				nodeToEdges[edge.First] = new List<Edge>();
			}

			if (!nodeToEdges.ContainsKey(edge.Second))
			{
				nodeToEdges[edge.Second] = new List<Edge>();
			}

			nodeToEdges[edge.First].Add(edge);
			nodeToEdges[edge.Second].Add(edge);
		}

		var distances = new int[nodes.Max() + 1];

		for (int i = 0; i < distances.Length; i++)
		{
			distances[i] = int.MaxValue;
		}

		distances[nodes.First()] = 0;

		var queue = new SortedSet<int>(Comparer<int>.Create((f, s) => distances[f] - distances[s]))
		{
			nodes.First()
		};

		while (queue.Any())
		{
			var min = queue.Min();
			queue.Remove(min);

			foreach (var edge in nodeToEdges[min])
			{
				var otherNode = edge.First == min
					? edge.Second
					: edge.First;

				if (distances[otherNode] == int.MaxValue)
				{
					queue.Add(otherNode);
				}

				var newDistance = distances[min] + edge.Weight;

				if (newDistance < distances[otherNode])
				{
					distances[otherNode] = newDistance;
					queue = new SortedSet<int>(queue, Comparer<int>.Create((f, s) => distances[f] - distances[s]));
				}
			}
		}

		Console.WriteLine(String.Join("\n", distances));
	}
}