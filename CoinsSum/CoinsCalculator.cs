namespace CoinsSum;

public class CoinsCalculator
{
	public static void Main()
	{
		List<int> coins = new() { 1, 2, 3, 5, 10, 15, 20, 25, 50 };
		int targetSum = int.Parse(Console.ReadLine());

		var result = Calculate(coins, targetSum);

		Console.WriteLine($"Target sum: {targetSum}");

		foreach (var (key, value) in result)
		{
			Console.WriteLine($"Coin(s): {key}, Times: {value}");
		}
	}

	private static Dictionary<int, int> Calculate(List<int> coins, int targetSum)
	{
		var result = new Dictionary<int, int>();

		coins = coins.OrderByDescending(x => x).ToList();

		var currentIndex = 0;
		var currentSum = 0;
		while (currentSum != targetSum && currentIndex != coins.Count)
		{
			var currentCoin = coins[currentIndex];

			if (currentSum + currentCoin > targetSum)
			{
				currentIndex++;
				continue;
			}

			var reminder = targetSum - currentSum;
			var coinsToTake = reminder / currentCoin;

			if (coinsToTake > 0)
			{
				result[currentCoin] = coinsToTake;
				currentSum += currentCoin * coinsToTake;
			}
		}

		if (currentSum != targetSum)
		{
			throw new Exception("Try again");
		}

		return result;
	}
}