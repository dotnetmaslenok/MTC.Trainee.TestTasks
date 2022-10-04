
class Program
{
	static void Main(string[] args)
	{
		TransformToElephant();

		Console.WriteLine("Муха");
		Console.WriteLine("Failed to skip");
	}

	static void TransformToElephant()
	{
		if (AppDomain.CurrentDomain.GetData("Слон") == null)
		{
			Console.WriteLine("Слон");
			Console.SetOut(TextWriter.Null);
			AppDomain.CurrentDomain.SetData("Слон", string.Empty);

			Main(Array.Empty<string>());
		}
	}
}
