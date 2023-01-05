namespace Multitasking;

internal class _02_TaskMitReturn
{
	static void Main(string[] args)
	{
		Task<int> t = Task.Run(Run); //Task.Run nimmt automatisch <int> an
		Console.WriteLine(t.Result); //t.Result blockt den Main Thread

		for (int i = 0; i < 100; i++) //Schleife wird durch t.Result blockiert
			Console.WriteLine(i);

		Task t2 = Task.Run(() => Console.WriteLine("Etwas")); //Task mit anonymer Methode

		Task t3 = Task.Run(() => 
		{
			Console.WriteLine("Mehrzeilige");
			Console.WriteLine("anonyme");
			Console.WriteLine("Methode");
		});

		t.Wait(); //Warte auf diesen Task
		Task.WaitAll(t, t2, t3); //Warte bis alle diese Tasks fertig sind
		Task.WaitAny(t, t2, t3); //Warte bis ein beliebiger Task fertig ist
	}

	static int Run()
	{
		int sum = 0;
		for (int i = 0; i < 1000; i++)
		{
			sum += i;
			//Thread.Sleep(1);
		}
		return sum;
	}
}
