namespace Multitasking;

internal class _04_TaskExceptions
{
	static void Main(string[] args)
	{
		try
		{
			Task t1, t2, t3;
			t1 = Task.Run(Exception1);
			t2 = Task.Run(Exception2);
			t3 = Task.Run(Exception3);

			Task.WaitAll(t1, t2, t3); //Auf Tasks warten um Exceptions zu sehen
		}
		catch (AggregateException ex)
		{
			foreach (Exception ex2 in ex.InnerExceptions) //Alle gesammelten Exceptions durchgehen
			{
				Console.WriteLine(ex2.Message);
			}
		}
	}

	static void Exception1()
	{
		Thread.Sleep(1000);
		throw new DivideByZeroException();
	}

	static void Exception2()
	{
		Thread.Sleep(2000);
		throw new StackOverflowException();
	}

	static void Exception3()
	{
		Thread.Sleep(3000);
		throw new OutOfMemoryException();
	}
}
