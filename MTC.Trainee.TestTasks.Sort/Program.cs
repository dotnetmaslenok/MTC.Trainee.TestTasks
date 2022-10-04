using System.ComponentModel.DataAnnotations;

static class Program
{
	static void Main()
	{
		var inputStream = new List<int> { 11, 3, 55, 7, 99, 67, 43, 41, 42 };
		foreach (var item in inputStream.Sort(33, 99))
		{
			Console.WriteLine(item);
		}
	}

	static IEnumerable<int> Sort(this IEnumerable<int> inputStream, int sortFactor, [Range(0, 2000)] int maxValue)
	{
		int min = 0;
		var values = new int[maxValue + 1];

		foreach (int item in inputStream)
		{
			values[item]++;

			int max = item - sortFactor;
			while (min < max)
			{
				while (values[min]-- > 0)
				{
					yield return min;
				}

				min++;
			}
		}

		while (min < values.Length)
		{
			while (values[min]-- > 0)
			{
				yield return min;
			}

			min++;
		}
	}
}