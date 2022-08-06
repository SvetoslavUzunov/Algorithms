namespace RecursiveArraySum;

public class Program
{
	public static void Main()
	{
		var array = new int[] { 1, 2, 3, 4, 5 };

		var sum = Sum(array, 0);

		Console.WriteLine(sum);
	}

	private static int Sum(int[] array, int index)
	{
		if (index == array.Length)
		{
			return 0;
		}

		return array[index] += Sum(array, index + 1);
	}
}