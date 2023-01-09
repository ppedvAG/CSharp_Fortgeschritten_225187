using System.Reflection;

namespace Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		Program p = new();
		Type pt = p.GetType(); //Typ holen mit GetType() über Objekt
		Type t = typeof(Program); //Typ holen durch typeof(<Klassenname>)

		object o = Activator.CreateInstance(pt); //Objekt über Typ erstellen

		pt.GetMethods(); //Alle Methoden anschauen
		pt.GetMethod("Test").Invoke(o, null); //Methode über Reflection aufrufen, braucht ein Objekt und hat optional Parameter
		pt.GetMethod("Test2").Invoke(o, new[] { "Zwei Text" }); //Methode mit Parameter aufrufen

		pt.GetField("Zahl").SetValue(o, 6); //Feld über Reflection setzen
		Console.WriteLine(pt.GetField("Zahl").GetValue(o));

		///////////////////////////////////////////////////////////

		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt nur über Strings erstellen

		Assembly assembly = Assembly.GetExecutingAssembly(); //Informationen über das derzeitige Projekt erhalten

		assembly.GetTypes(); //Alle Typen aus dem Assembly finden

		Type x = assembly.GetTypes().First(e => e.Name == "Program"); //Einzelnen Typen finden über String mithilfe von Linq

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2023_01_02\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll";

		Assembly loaded = Assembly.LoadFrom(path); //DLL Laden

		Type compType = loaded.GetType("DelegatesEvents.Component"); //Typ der Komponente finden

		object comp = Activator.CreateInstance(compType);
		compType.GetEvent("ProcessCompleted").AddEventHandler(comp, () => Console.WriteLine("Prozess fertig"));
		compType.GetEvent("Progress").AddEventHandler(comp, (int i) => Console.WriteLine($"Fortschritt: {i}"));
		compType.GetMethod("StartProcess").Invoke(comp, null);
	}

	public int Zahl;

	public void Test() => Console.WriteLine("Test ausgeführt");

	public void Test2(string s) => Console.WriteLine(s);
}