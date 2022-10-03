static class Program
{
	static void Main()
	{
		var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

		foreach (var item in list.EnumerateFromTail(20))
		{
			Console.WriteLine($"{item.item} {item.tail}");
		}
	}

	static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
	{
		if (tailLength.HasValue)
		{
			var collection = (ICollection<T>)enumerable;
			var counter = 0;

			foreach (var item in collection)
			{
				counter++;

				yield return (item, collection.Count - counter <= tailLength ? collection.Count - counter : null);
			}
		}
	}
}