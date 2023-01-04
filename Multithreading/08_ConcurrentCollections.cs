using System.Collections.Concurrent;

namespace Multithreading;

internal class _08_ConcurrentCollections
{
	static void Main(string[] args)
	{
		ConcurrentBag<int> list = new(); //Thread-sichere Liste

		ConcurrentDictionary<int, string> dict = new(); //Thread-sicheres Dictionary
		dict.TryAdd(1, "123");
	}
}
