namespace RecursiveDrawing;

public class Program
{
	public static void Main()
	{
		var number = int.Parse(Console.ReadLine());
		
		Draw(number);
	}

	private static void Draw(int number)
	{
		if (number == 0)
		{
			return;
		}

		Console.WriteLine(new String('*', number));
		Draw(number - 1);
		Console.WriteLine(new String('#', number));
	}
}