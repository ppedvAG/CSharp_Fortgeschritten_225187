using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		Stopwatch sw = Stopwatch.StartNew();
		//sw.Run(() =>
		//{
		//	Toast();
		//	Geschirr();
		//	Kaffee();
		//}); //7s, sequentiell

		//sw.Run(() => 
		//{
		//	Task.Run(Toast);
		//	Task.Run(Geschirr);
		//	Task.Run(Kaffee);
		//}); //6ms, Main Thread läuft weiter
		//Console.ReadKey();

		//sw.Run(() =>
		//{
		//	ToastTaskAsync(); //Methoden werden als Tasks ausgeführt, weil sie async sind
		//	GeschirrTaskAsync();
		//	KaffeeTaskAsync();
		//});

		//sw.Start();
		//Task<Toast> toast = ToastAsync(); //Starte das Toast machen
		//Task<Tasse> tasse = GeschirrAsync(); //Starte das Geschirr herrichten
		//Tasse t = await tasse; //Um Kaffee zu starten muss die Tasse fertig sein
		//Task<Kaffee> kaffee = KaffeeAsync(t); //Die fertige Tasse übergeben
		//Kaffee k = await kaffee;
		//Toast essen = await toast; //Warte bis Toast & Kaffee fertig sind
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //4s

		//sw.Run(async () => //async Lambda Expression
		//{
		//	Task<Toast> toast = ToastAsync(); //Starte das Toast machen
		//	Task<Tasse> tasse = GeschirrAsync(); //Starte das Geschirr herrichten
		//	Tasse t = await tasse; //Um Kaffee zu starten muss die Tasse fertig sein
		//	Task<Kaffee> kaffee = KaffeeAsync(t); //Die fertige Tasse übergeben
		//	Kaffee k = await kaffee;
		//	Toast essen = await toast; //Warte bis Toast & Kaffee fertig sind
		//});

		//Kurzform von obigem Code
		Task<Toast> t = ToastAsync();
		Kaffee k = await KaffeeAsync(await GeschirrAsync());
		Toast t2 = await t;
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Geschirr()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async void ToastTaskAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async void GeschirrTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static async void KaffeeTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async Task<Toast> ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> GeschirrAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee();
	}
}

public static class Extensions
{
	public static void Run(this Stopwatch sw, Action action)
	{
		sw.Start();
		action();
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
		sw.Reset();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }