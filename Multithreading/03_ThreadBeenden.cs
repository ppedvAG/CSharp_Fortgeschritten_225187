namespace Multithreading;

internal class _03_ThreadBeenden
{
	static void Main(string[] args)
	{
		try
		{
			Thread t = new Thread(Run);
			t.Start();

			Thread.Sleep(1000); //Warte am Main Thread 1s

			t.Interrupt(); //Beende den Thread
			//t.Abort(); //Deprecated
		}
		catch (ThreadInterruptedException e)
		{
			//Exception kann nicht hier oben gefangen werden
		}
	}

	static void Run()
	{
		try
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(200);
				Console.WriteLine($"Side Thread: {i}");
			}
		}
		catch (ThreadInterruptedException) //Exception kann nur hier unten gefangen werden
		{
			Console.WriteLine("Thread wurde unterbrochen");
		}
	}
}
