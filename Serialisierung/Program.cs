using Microsoft.VisualBasic.FileIO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//NewtonsoftJson();

		//SystemJson();

		//Xml();

		//Binary();

		//CSV();
	}

	static void NewtonsoftJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//JsonSerializerSettings settings = new(); //Einstellungen für die Serialisierung/Deserialisierung
		//settings.Formatting = Formatting.Indented; //Schönes Json generieren
		//settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; //Zirkelbezüge ignorieren (Baumstrukturen)

		//string json = JsonConvert.SerializeObject(fahrzeuge, settings); //JsonConvert: Klasse zum Erstellen von Json Strings und Konvertieren von Json Strings zu Objekten
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings); //Deserialisierung in alle Listentypen möglich (List, Array, ObservableCollection, ...)

		/////////////////////////////////////////////

		//JToken doc = JToken.Parse(json); //Json zu "JsonDocument" umwandeln um es Stück für Stück durchzugehen
		//foreach (JToken jt in doc)
		//{
		//	if (jt["MaxV"] != null) //Überprüfen ob das Feld innerhalb des Objekts existiert
		//		Console.WriteLine(jt["MaxV"].Value<int>()); //In jedes Json Element hereinschauen und bestimmte Werte angreifen

		//	Fahrzeug f = JsonConvert.DeserializeObject<Fahrzeug>(jt.ToString()); //Json zu einzelnem Objekt konvertieren
		//}
	}

	static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		JsonSerializerOptions options = new();
		options.WriteIndented = true;
		options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

		string json = JsonSerializer.Serialize(fahrzeuge, options);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options);

		////////////////////////////////////////////

		JsonDocument doc = JsonDocument.Parse(json);
		JsonElement.ArrayEnumerator ae = doc.RootElement.EnumerateArray(); //Hier Umwandlung zu einem ArrayEnumerator erforderlich
		foreach (JsonElement je in ae)
		{
			Console.WriteLine(je.GetProperty("MaxV").GetInt32());

			Fahrzeug f = je.Deserialize<Fahrzeug>(); //Kann direkt in ein Objekt konvertieren wenn ich das Objekt kenne
			Console.WriteLine(f.MaxV);
		}
	}

	static void Xml()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new(fahrzeuge.GetType()); //XmlSeralizer muss erstellt werden und braucht einen Typen
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		{
			xml.Serialize(fs, fahrzeuge);
		}

		using (FileStream fs = new FileStream(filePath, FileMode.Open))
		{
			List<Fahrzeug> fzg = xml.Deserialize(fs) as List<Fahrzeug>; //Hier keine Methode mit Generic -> Casten
		}

		///////////////////////////////////////////
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(File.ReadAllText(filePath));
		foreach (XmlNode node in doc.ChildNodes[1]) //[1] um den Header zu überspringen
		{
			//Console.WriteLine(node.ChildNodes.OfType<XmlNode>().First(e => e.Name == "MaxV").InnerText); //XmlNodeList -> IEnumerable<XmlNode> konvertieren um Linq benutzen zu können
			Console.WriteLine(node.Attributes["MaxV"].Value); //Einzelne Werte über Attribute auslesen
		}
	}

	static void Binary()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		BinaryFormatter formatter = new BinaryFormatter();
		using (StreamWriter sw = new StreamWriter(filePath))
		{
			formatter.Serialize(sw.BaseStream, fahrzeuge);
		}

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> readFzg = formatter.Deserialize(sr.BaseStream) as List<Fahrzeug>;
		}
	}

	static void CSV()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		TextFieldParser tfp = new(filePath);
		tfp.SetDelimiters(";");
		//Hier Header überspringen falls notwendig
		while (!tfp.EndOfData)
		{
			string[] fields = tfp.ReadFields();
			Fahrzeug f = new Fahrzeug(int.Parse(fields[0]), int.Parse(fields[1]), (FahrzeugMarke) int.Parse(fields[2]));
		}
	}
}

[Serializable]
public class Fahrzeug
{
	//[JsonIgnore] //Feld ignorieren (beiden Frameworks)
	//[JsonPropertyName("Identifier")] //Feld umbenennen (System.Json)
	//[JsonProperty("Identifier")] //Feld umbenennen (Newtonsoft.Json)
	public int ID { get; set; }

	//[XmlIgnore]
	//[XmlElement("Maximalgeschwindigkeit")] //Name ändern
	[XmlAttribute]
	public int MaxV { get; set; }

	[field: NonSerialized] //"BinaryIgnore"
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int iD, int maxV, FahrzeugMarke marke)
	{
		ID = iD;
		MaxV = maxV;
		Marke = marke;
	}

	public Fahrzeug()
	{
		//Für XML
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }