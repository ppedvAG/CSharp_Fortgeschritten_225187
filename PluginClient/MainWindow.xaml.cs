using PluginBase;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PluginClient;

public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2023_01_02\Plugin\bin\Debug\net6.0\Plugin.dll";
		Assembly loaded = Assembly.LoadFrom(Pfad.Text);
		Type t = loaded.GetTypes().First(e => e.GetInterface("IPlugin") != null); //Den ersten Typ finden der das Interface hat (es gibt nur einen Typen)
		IPlugin plugin = Activator.CreateInstance(t) as IPlugin; //Objekt vom Plugin erstellen als IPlugin Objekt

		Info.Text += $"Name: {plugin.Name}\nBeschreibung: {plugin.Description}\nVersion: {plugin.Version}\nAutor: {plugin.Author}";

		foreach (MethodInfo mi in t.GetMethods().Where(e => e.GetCustomAttribute(typeof(ReflectionVisibleAttribute)) != null))
		{
			Button b = new Button();
			b.Content = mi.Name + $"({string.Join(',', mi.GetParameters().Select(e => $"{e.ParameterType.Name} {e.Name}"))})";
			b.Click += (sender, args) => mi.Invoke(plugin, new object[] { 5.5, 2.2 });
			Stack.Children.Add(b);
		}
	}
}
