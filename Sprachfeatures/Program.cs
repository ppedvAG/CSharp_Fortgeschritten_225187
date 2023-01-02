namespace Sprachfeatures
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Methode(z: "", x: "", y: "");

			Program p = new(name: "", gehalt: 10000);

			string vorname = "lukas";
			string fix = char.ToUpper(vorname[0]) + vorname[1..].ToLower();

			int alter = 24;
			//String Interpolation
			//Code in Strings einbauen
			string code = $"Der Vorname ist: {vorname + fix}, {alter}";

			Console.WriteLine("{0}, {1}", vorname, alter);

			//Verbatim String
			//Nimmt den String genau so wie er geschrieben ist
			string pfad = @"C:\Users\lk3\source\repos";
			string escape = @"\n\t\r\0";

			AccessModifier mod = new() { Name = "" };
			//mod.Name = "";

			Person person = new Person(3, "Test");
			person.Test();
		}

		static int Methode(string x, string y, string z) => 0;

		public Program(string name = "", int alter = 0, string adresse = "", string geschlecht = "", int gehalt = 0)
		{

		}
	}

	record Person(int ID, string Name)
	{
		public void Test()
		{

		}
	}

	class AccessModifier //Klassen und Member ohne Modifier sind internal
	{
		public string Name { get; init; } = ""; //Überall sichtbar, auch außerhalb vom Projekt

		private int Alter { get; set; } //Kann nur innerhalb dieser Klasse gesehen werden

		internal string Wohnort { get; set; } //Überall sichtbar, außer außerhalb vom Projekt

		protected string Lieblingsfarbe { get; set; } //Nur in der Klasse und in Unterklassen sichtbar (auch außerhalb)

		protected internal string Lieblingsnahrung { get; set; } //Kann im Projekt überall (durch internal) und in Unterklassen außerhalb vom Projekt (protected)

		protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und in Unterklassen nur im Projekt gesehen werden
	}

	interface ITest
	{
		static int Test = 5;
	}
}