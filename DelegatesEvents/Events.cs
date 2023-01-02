namespace DelegatesEvents;

internal class Events
{
	//event: Statischer Punkt an den Methoden angehängt werden können
	static event EventHandler TestEvent;

	//EventHandler: Delegate das sender und args vorgibt (hauptsächlich in WPF, ASP, Xamarin zu finden)
	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Methode anhängen ohne new, Event kann nicht erstellt werden
		TestEvent += (sender, args) => { }; //Anonymes Event anhängen
		TestEvent(null, EventArgs.Empty); //Event ausführen

		ArgsEvent += Events_ArgsEvent;
	}

	private static void Events_TestEvent(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private static void Events_ArgsEvent(object sender, TestEventArgs e)
	{
		throw new NotImplementedException();
	}
}

public class TestEventArgs : EventArgs
{

}