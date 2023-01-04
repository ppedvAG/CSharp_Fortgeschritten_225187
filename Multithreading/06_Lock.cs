namespace Multithreading;

internal class _06_Lock
{
	static int Counter = 0;

	static object Lock = new object();

	static void Main(string[] args)
	{
		for (int i = 0; i < 1000; i++)
		{
			new Thread(ZahlPlusPlus).Start();
		}
	}

	static void ZahlPlusPlus()
	{
		for (int i = 0; i < 1000; i++)
		{
			lock (Lock) //Counter sperren damit nicht mehrere Threads gleichzeitig draufgreifen können
			{
				Counter++; //Kein Lock/Monitor sollte Crash verursachen
			} //Lock wird geöffnet

			Monitor.Enter(Lock); //Monitor und Lock haben 1:1 den selben Code
			Counter++;
			Monitor.Exit(Lock);
		}
	}
}
