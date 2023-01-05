using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Progress.Value++;
		} //UI Thread wird blockiert
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Task.Run(() => //UI Updates von Side Tasks sind nicht erlaubt
		{
			Dispatcher.Invoke(() => Progress.Value = 0); //Dispatcher.Invoke um UI Updates auf dem Main Thread auszuführen
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Dispatcher.Invoke(() => Progress.Value++);
			}
		});
	}

	private async void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(25);
			Progress.Value++;
		}
	}

	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		Progress.Maximum = 2;

		using HttpClient client = new();
		Task<HttpResponseMessage> request = client.GetAsync(@"http://www.gutenberg.org/files/54700/54700-0.txt");
		//UI Update: Text lädt...
		Ergebnis.Text = "Text lädt...";
		HttpResponseMessage resp = await request;
		Progress.Value++;

		Task<string> text = resp.Content.ReadAsStringAsync();
		//UI Update: Text wird ausgelesen...
		Ergebnis.Text = "Text wird ausgelesen...";
		await Task.Delay(1000);

		Ergebnis.Text = await text;
		Progress.Value++;
	}

	private async void Button_Click_4(object sender, RoutedEventArgs e)
	{
		List<int> ints = Enumerable.Range(0, 100_000_000).ToList();
		await Parallel.ForEachAsync(ints, (item, ct) =>
		{
			Console.WriteLine(item * 10);

			return ValueTask.CompletedTask;
		});

		IAsyncEnumerable<int> liste = null;
		await foreach (int i in liste)
		{

		}
	}
}
