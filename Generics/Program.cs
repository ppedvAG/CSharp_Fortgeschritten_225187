﻿using System.Collections;

namespace Generics;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new List<string>(); //Generic: T wird nach unten übernommen (hier T = string)
		list.Add("123"); //T wird durch string ersetzt Add(T) -> Add(string)

		List<int> ints = new List<int>(); //T wird durch int ersetzt
		ints.Add(123); //Add(T) -> Add(int)

		Dictionary<string, int> keyValuePairs = new Dictionary<string, int>(); //Klasse mit 2 Generics: TKey -> string, TValue -> int
		keyValuePairs.Add("123", 123);
	}
}

public class DataStore<T>
	: IProgress<T>, //T wird bei Vererbung weitergegeben
	  IEquatable<int> //int statt T als fixer Typ
{
	private T[] data; //T als Typ

	public List<T> Data => data.ToList(); //Generic wird nach unten weitergegeben

	public void Add(int index, T value) //T als Parameter
	{
		data[index] = value;
	}

	public T Get(int i) //T als Rückgabewert
	{
		if (i < 0 || i > data.Length)
			return default(T); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		return data[i];
	}

	public void Report(T value) //T kommt von Interface
	{
		throw new NotImplementedException();
	}

	public bool Equals(int other)
	{
		throw new NotImplementedException();
	}

	public void PrintType<MyType>() //Methode mit Generic, T von oben nicht nochmal definieren
	{
		Console.WriteLine(default(MyType)); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		Console.WriteLine(typeof(MyType)); //Typ Objekt aus dem Generic erzeugen
		Console.WriteLine(nameof(MyType)); //Gibt den Namen des Typs aus ("int", "string", "bool", ...)

		//if (MyType is int) { } //Nicht möglich

		if (typeof(MyType) == typeof(int)) //Typvergleiche mit Generics
		{

		}
	}
}

public class DataStore2<T> : DataStore<T> { } //Klassen mit T vererben: braucht wieder T beim Klassennamen