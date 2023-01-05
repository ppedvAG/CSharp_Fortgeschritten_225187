namespace Multitasking;

internal class _06_WhenAll
{
	static void Main(string[] args)
	{
		List<Task<int>> tasks = new();

		for (int i = 0; i < 1000; i++)
		{
			tasks.Add(Task.Run(() => i * i));
		}

		Task<int[]> ergebnisse = Task.WhenAll(tasks); //Gibt einen Task<int[]>
		int[] erg = ergebnisse.Result; //Ergebnisse holen
	}
}
