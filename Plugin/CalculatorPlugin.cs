using PluginBase;

namespace Plugin;

public class CalculatorPlugin : IPlugin
{
	public string Name => "Calculator";

	public string Description => "Ein einfacher Rechner";

	public string Version => "1.0";

	public string Author => "Lukas Kern";

	[ReflectionVisible]
	public double Addiere(double z1, double z2) => z1 + z2;

	[ReflectionVisible]
	public double Subtrahiere(double z1, double z2) => z1 - z2;
}