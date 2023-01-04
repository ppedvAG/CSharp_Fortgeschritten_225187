namespace Multithreading;

internal class _04_ThreadMitCancellationToken
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new(); //Sender
		CancellationToken token = cts.Token; //Empfänger

		ParameterizedThreadStart pts = new(Run);
		Thread t = new Thread(pts);
		t.Start(token); //Hier Token weitergeben

		Thread.Sleep(1000);

		cts.Cancel(); //Canceled alle Token
	}

	static void Run(object o)
	{
		try
		{
			if (o is CancellationToken ct)
			{
				for (int i = 0; i < 10; i++)
				{
					Thread.Sleep(200);
					Console.WriteLine($"Side Thread: {i}");

					ct.ThrowIfCancellationRequested(); //OperationCanceledException werfen um Thread zu beenden

					if (ct.IsCancellationRequested)
						break;
				}
			}
		}
		catch (OperationCanceledException)
		{
			Console.WriteLine("Thread wurde beendet mit CancellationToken");
		}
	}
}
