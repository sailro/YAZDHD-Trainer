using System;
using System.IO;
using SharpMonoInjector;
using TrainerKit.Properties;

namespace TrainerKit;

internal class Program
{
	public static void Main()
	{
		try
		{
			var location = System.Reflection.Assembly.GetEntryAssembly()!.Location;
			var bytes = File.ReadAllBytes(location);

			using var injector = new Injector("YAZD_HD");
			var intptr = injector.Inject(bytes, typeof(Context).Namespace, nameof(Context), nameof(Context.Load));

			Console.WriteLine(Strings.InjectorSuccess, Path.GetFileName(location), injector.Is64Bit ? $"0x{intptr.ToInt64():X16}" : $"0x{intptr.ToInt32():X8}");
		}
		catch (Exception e)
		{
			Console.WriteLine(Strings.InjectorFailure, e.Message);
		}
	}
}
