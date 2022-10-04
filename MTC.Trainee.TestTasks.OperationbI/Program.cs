using System.Globalization;

class Program
{
	static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

	class Number
	{
		private readonly int _number;

		public Number(int number)
		{
			_number = number;
		}

		public static string operator +(Number left, string right)
		{
			if (int.TryParse(right, out int rightValue))
			{
				return $"{left._number + rightValue}";
			}

			return left._number + right;
		}

		public override string ToString()
		{
			return _number.ToString(_ifp);
		}
	}

	static void Main()
	{
		int someValue1 = 10;
		int someValue2 = 5;

		string result = new Number(someValue1) + someValue2.ToString(_ifp);
		Console.WriteLine(result);
		Console.ReadKey();
	}
}