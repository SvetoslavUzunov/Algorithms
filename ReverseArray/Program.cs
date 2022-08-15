namespace ReverseArray;

public class Program
{
	public static void Main()
	{
		var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

		var reversedArray = ReverseArray(array, array[^1], 0);

		Console.WriteLine(String.Join(' ', reversedArray));
	}

	private static int[] ReverseArray(int[] array, int count, int step)
	{
		if (count == 0)
		{
			return Array.Empty<int>();
		}

		array[step] = count;

		ReverseArray(array, count - 1, step + 1);

		return array;
	}
}