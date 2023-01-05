namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		Task<double> t1 = Task.Run(() =>
		{
			Thread.Sleep(1000);
			//throw new Exception();
			return Math.Pow(4, 23);
		});
		t1.ContinueWith(vorherigerTask => Console.WriteLine(vorherigerTask.Result)); //Tasks verketten, Code ausgeführt wenn der vorherige Task fertig ist, vorheriger Task ist in der Variable zu finden
		t1.ContinueWith(t => Console.WriteLine(t.Result * 2)); //Dieser Task wird gleichzeitig mit dem Task darüber ausgeführt
		t1.ContinueWith(t => Console.WriteLine("Exception"), TaskContinuationOptions.OnlyOnFaulted); //Über TaskContinuationOptions einen Baum bauen mit Verkettungen -> nur bei Exceptions
		t1.ContinueWith(t => Console.WriteLine(t.Result * 8), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.NotOnCanceled); //nur wenn der Task fertig ist und nicht abgebrochen wurde

		Console.ReadKey();
	}
}
