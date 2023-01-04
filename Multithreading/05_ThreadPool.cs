namespace Multithreading;

internal class _05_ThreadPool
{
	static void Main(string[] args)
	{
		ThreadPool.QueueUserWorkItem(Methode1);
		ThreadPool.QueueUserWorkItem(Methode2);
		ThreadPool.QueueUserWorkItem(Methode3);

		Thread.Sleep(1000);

		//Hintergrundthreads werden hier abgebrochen

		Console.ReadKey();
	}

	public static void Methode1(object o)
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Methode1: {i}");
			Thread.Sleep(25);
		}
	}

	public static void Methode2(object o)
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Methode2: {i}");
			Thread.Sleep(25);
		}
	}

	public static void Methode3(object o)
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Methode3: {i}");
			Thread.Sleep(25);
		}
	}
}
