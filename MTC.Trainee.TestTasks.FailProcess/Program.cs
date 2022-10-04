using System.Diagnostics;

public class Program
{
	static void Main()
	{
		try
		{
			FailProcess(FailProcessUsingGetProcesses);
		}
		catch
		{

		}

		Console.WriteLine("Failed to fail process");
		Console.ReadKey();
	}

	static void FailProcess(Action failProcessAction)
	{
		failProcessAction();
	}

	static void FailProcessUsingEnvironmentExit()
	{
		Environment.Exit(-1);
	}

	static void FailProcessUsingEnvironmentFailFast()
	{
		Environment.FailFast("Successful crash of the process");
	}

	static void FailProcessUsingGetProcesses()
	{
		foreach (var process in Process.GetProcessesByName("MTC.Trainee.TestTasks.FailProcess"))
		{
			process.Kill();
			process.WaitForExit();
			process.Dispose();
		}
	}
}