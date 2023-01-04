namespace Multithreading;

internal class _07_Mutex
{
	static void Main(string[] args)
	{
		Mutex m;
		if (Mutex.TryOpenExisting("Multithreading", out m)) //Wenn die Applikation bereits gestartet ist
		{
			Console.WriteLine("Applikation ist bereits gestartet");
			Environment.Exit(0);
		}
		else
		{
			m = new Mutex(true, "Multithreading");
		}

		Thread.Sleep(10000);

		//Am Ende der Applikation Mutex wieder freigegeben werden
		m.ReleaseMutex();
	}
}
