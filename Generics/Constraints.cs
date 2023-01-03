namespace Generics;

internal class Constraints
{
	static void Main(string[] args)
	{
		DataStore4<Constraints> ds4;
		DataStore5<DayOfWeek> ds5;
	}

	public class DataStore1<T> where T : class { } //T muss ein Referenztyp sein

	public class DataStore2<T> where T : struct { } //T muss ein Wertetyp sein

	public class DataStore3<T> where T : Program { } //T muss die Klasse selber sein oder eine Unterklasse sein

	public class DataStore4<T> where T : new() { } //T muss einen Standardkonstruktor haben

	public class DataStore5<T> where T : Enum { } //T muss ein Enum sein (kein Enumwert)

	public class DataStore6<T> where T : Delegate { } //T muss ein Delegate sein

	public class DataStore7<T> where T : unmanaged { } //Nur Basisdatentypen und ein paar weitere Typen
	//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types

	public class DataStore8<T> where T : class, Enum, new() { } //Mehrere Constraints auf ein Generic

	public class DataStore9<T1, T2>
		where T1 : class
		where T2 : struct
	{ }

	public class DataStore10<T1, T2, T3, T4, T5, T6, T7> { } //Beliebig viele Generics möglich

	public void Test<T>() where T : unmanaged //Constraints bei Methode hinzufügen
	{

	}
}
