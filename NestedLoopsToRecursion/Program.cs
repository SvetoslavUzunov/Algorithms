namespace NestedLoopsToRecursion;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		Generate(n, 1);
	}

	private static void Generate(int n, int index)
	{
		if (index == n)
		{
			return;
		}

		for (int i = 1; i <= n; i++)
		{
			Console.WriteLine($"{i} {index}");
			Generate(n, index + 1);
			Console.WriteLine($"{index} {i}");
		}
	}
}