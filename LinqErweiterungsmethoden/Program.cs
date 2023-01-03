using System.Text;

namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Liste von <Start> mit <Anzahl> Elementen
		//Liste von 1-20
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Gibt das erste Element zurück, Exception wenn kein Element gefunden wird
		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element zurück, default(T) wenn kein Element gefunden wird

		Console.WriteLine(ints.Last()); //Gibt das letzte Element zurück, Exception wenn kein Element gefunden wird
		Console.WriteLine(ints.LastOrDefault()); //Gibt das letzte Element zurück, default(T) wenn kein Element gefunden wird

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Exception
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Lambda
		//Alle Fahrzeuge mit MaxV >= 200
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs mit MaxV >= 200
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200);

		//Autos nach der Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert
		fahrzeuge.OrderByDescending(e => e.Marke); //Absteigend

		//Autos nach Marke und danach nach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//fahrzeuge = fahrzeuge.OrderBy(e => e.Marke).ToList(); //Originale Liste sortieren

		//Alle Marken in der Liste finden
		fahrzeuge.Select(e => e.Marke); //Liste von FahrzeugMarken
		fahrzeuge.Select(e => e.MaxV); //Liste von ints

		//Jede Marke nur einmal finden
		fahrzeuge.Select(e => e.Marke).Distinct();

		//Fahren alle Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		//Ist in der Liste mindestens ein Element enthalten?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi); //4

		//Linq Abfragen mit Where vereinfachen
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.Audi).Count();
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi);
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.Audi).First();
		fahrzeuge.First(e => e.Marke == FahrzeugMarke.Audi);

		//Wie schnell fahren unsere Autos im Durchschnitt?
		fahrzeuge.Average(e => e.MaxV);
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das Auto mit der kleinsten Geschwindigkeit

		fahrzeuge.Max(e => e.MaxV); //Die größte Geschwindigkeit
		fahrzeuge.MaxBy(e => e.MaxV); //Das Auto mit der größten Geschwindigkeit

		//Fahrzeuge in X große Teile aufteilen (Rest kommt in den letzten Teil)
		fahrzeuge.Chunk(5);

		//Überspringe X Elemente, nimm Y Elemente, wird häufig kombiniert
		fahrzeuge.Skip(2).Take(5);

		//Die 5 schnellsten Fahrzeuge
		fahrzeuge.OrderByDescending(e => e.MaxV).Take(5);

		//Liste umdrehen
		fahrzeuge.Reverse(); //Funktion von der List
		fahrzeuge.Reverse<Fahrzeug>(); //Funktion von Linq (Generic angeben um Linq Funktion explizit zu benutzen)

		//ID hinzufügen
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count));
		Enumerable.Range(0, fahrzeuge.Count).Zip(fahrzeuge);

		//Dictionary erstellen weil einfacher zu benutzen
		Dictionary<int, Fahrzeug> zipDict =
			Enumerable.Range(0, fahrzeuge.Count)
				.Zip(fahrzeuge) //Liste von Tupel(int, Fahrzeug) -> unpraktisch
				.ToDictionary(e => e.First, e => e.Second); //ToDictionary: wandelt die Liste in ein Dictionary um (hat 2 Lambda Expressions)

		//Fahrzeuge nach Marke gruppieren (Audi Gruppe, BMW Gruppe, VW Gruppe)
		fahrzeuge.GroupBy(e => e.Marke);

		//Grouping zu einem Dictionary konvertieren
		Dictionary<FahrzeugMarke, List<Fahrzeug>> grouped = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.ToList());

		//grouped[FahrzeugMarke.Audi] //Einzelne Gruppe angreifen

		//Alle Geschwindigkeiten aufsummieren
		fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxV);

		//Schöne Ausgabe aus der Liste generieren
		Console.WriteLine(fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n"));

		//Performante Version
		Console.WriteLine(fahrzeuge.Aggregate(new StringBuilder(), (agg, fzg) => agg.AppendLine($"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.")).ToString());
		#endregion

		#region Erweiterungsmethoden
		int x = 439875;
		x.Quersumme();
		Console.WriteLine(3427592.Quersumme());

		fahrzeuge.Shuffle();
		zipDict.Shuffle();
		#endregion
	}
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

public enum FahrzeugMarke { Audi, BMW, VW }