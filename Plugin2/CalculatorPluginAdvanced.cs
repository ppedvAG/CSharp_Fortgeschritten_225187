using PluginBase;

namespace Plugin2;

public class CalculatorPluginAdvanced : IPlugin
{
	public string Name => "Calculator Advanced";

	public string Description => "Ein Fortgeschrittener Rechner";

	public string Version => "1.0";

	public string Author => "Lukas Kern";

	[ReflectionVisible]
	public double Multipliziere(double x, double y) => x * y;

	[ReflectionVisible]
	public double Dividiere(double x, double y) => x / y;
}