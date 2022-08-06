using System.Numerics;

namespace RecursiveFactoriel;

public class Program
{
	public static void Main()
	{
		var result = Factorial(123);

		Console.WriteLine(result);
	}

	private static BigInteger Factorial(int number)
	{
		if (number == 1)
		{
			return 1;
		}

		return number * Factorial(number - 1);
	}
}