namespace TopologicalSort;

public class Program
{
	private static List<int>[] graph;

	public static void Main()
	{
		graph = new List<int>[]
		{
			new List<int>{ 1, 2 },
			new List<int>{ 3, 4 },
			new List<int>{ 5 },
			new List<int>{ 2, 5 },
			new List<int>{ 3 },
			new List<int>{ }
		};

		var result = new List<int>();
		var nodes = new HashSet<int>();

		var nodesWithIncommingEdges = GetNodesWithIncommingEdges();
		for (int i = 0; i < graph.Length; i++)
		{
			if (!nodesWithIncommingEdges.Contains(i))
			{
				nodes.Add(i);
			}
		}

		while (nodes.Any())
		{
			var currentItem = nodes.First();
			nodes.Remove(currentItem);

			result.Add(currentItem);

			var children = graph[currentItem];
			graph[currentItem] = new List<int>();

			var leftNodesWithIncommingEdges = GetNodesWithIncommingEdges();
			foreach (var child in children)
			{
				if (!leftNodesWithIncommingEdges.Contains(child))
				{
					nodes.Add(child);
				}
			}
		}

		if (graph.SelectMany(x => x).Any())
		{
			Console.WriteLine("Error!");
		}
		else
		{
			Console.WriteLine(String.Join(" ", result));
		}
	}

	private static HashSet<int> GetNodesWithIncommingEdges()
	{
		var nodesWithIncommingEdges = new HashSet<int>();

		graph
			.SelectMany(x => x)
			.ToList()
			.ForEach(x => nodesWithIncommingEdges.Add(x));

		return nodesWithIncommingEdges;
	}
}