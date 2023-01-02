namespace DelegatesEvents;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action += Subtrahiere;
		action(6, 2);
		action?.Invoke(5, 3);

		DoAction(4, 6, Addiere); //Das Verhalten der Methode anpassen über den Action Parameter
		DoAction(5, 6, Subtrahiere);
		DoAction(3, 8, action);

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		pred += CheckForOne;
		bool b = pred(3); //Ergebnis der letzten Methode wird genommen
		bool? b2 = pred?.Invoke(3); //Drei mögliche Ergebnisse: true, false oder null wenn das Predicate null ist
		bool b3 = pred?.Invoke(3) == true; //false oder null -> false, sonst true

		DoPredicate(5, CheckForZero); //Das Verhalten der Methode anpassen über den Predicate Parameter
		DoPredicate(5, CheckForOne);
		DoPredicate(5, pred);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Rückgabetyp), bis zu 16 Parameter
		func += Dividiere;
		double d = func(5, 9); //Das letzte Ergebnis
		double? d2 = func?.Invoke(4, 7);

		DoFunc(4, 6, Multipliziere);
		DoFunc(3, 9, Dividiere);
		DoFunc(3, 9, func);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(4, 9, (x, y) => Console.WriteLine($"Das Ergebnis ist: {x + y}")); //Hier kein Rückgabewert möglich -> cw hat keinen Rückgabewert
		DoPredicate(4, (x) => { return x == 5; }); //Ist die gegebene Zahl gleich 5? (Lambda Expression muss einen bool zurückgeben)
		DoFunc(4, 9, (x, y) => { return (double) x % y; }); //Anonyme Methode bei Func mit double als Ergebnis

		List<int> x = Enumerable.Range(0, 100).ToList();
		//Alle geraden Zahl finden
		x.Where(e => e % 2 == 0);
		//Alle durch 3 teilbaren Zahlen finden
		x.Where(e => e % 3 == 0);
	}

	#region Action
	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	private static void DoAction(int v1, int v2, Action<int, int> addiere) => addiere?.Invoke(v1, v2);
	#endregion

	#region Predicate
	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	private static bool DoPredicate(int v, Predicate<int> pred) => pred?.Invoke(v) == true;
	#endregion

	#region Func
	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => arg1 / arg2;

	private static double DoFunc(int v1, int v2, Func<int, int, double> func) => func(v1, v2);
	#endregion
}
