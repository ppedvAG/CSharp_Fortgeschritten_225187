using System.Collections;

Wagon w1 = new();
Wagon w2 = new();
Console.WriteLine(w1 == w2);

Zug z = new();
z += w1;
z += w2;

z++;
z++;
z++;
z++;

foreach (Wagon w in z)
{

}

//z[3] = null;
//Console.WriteLine(z["Rot"]);
//Console.WriteLine(z[23, "Blue"]);

//var x = z.Wagons.Select(e => new { Anz = e.AnzSitze, HC = e.GetHashCode() }).ToList();
//Console.WriteLine(x[0].HC);

System.Timers.Timer timer = new();
timer.Interval = 1000;
timer.Elapsed += (sender, args) => Console.WriteLine("1s vergangen");
timer.Start();
Console.ReadKey(); //Main Thread aufhalten



public class Zug : IEnumerable
{
	public List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public Wagon this[int index]
	{
		get => Wagons[index];
		set => Wagons[index] = value;
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anzSitze, string farbe]
	{
		get => Wagons.First(e => e.AnzSitze == anzSitze && e.Farbe == farbe);
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new());
		return z;
	}
}

public class Wagon
{
	public int AnzSitze;
	public string Farbe;

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}