using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit;

internal static class Context
{
	public static string UserPath => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
	public static string ConfigFile => Path.Combine(UserPath, "yazdhd-trainerkit.ini");

	public static Lazy<Feature[]> Features => new(() => [.. FeatureFactory.GetAllFeatures().OrderBy(f => f.Name)]);

	public static string LastConsoleLog { get; set; } = string.Empty;
	public static void AddConsoleLog(string log)
	{
		LastConsoleLog = log;
	}

	[UsedImplicitly]
	public static void Load()
	{
		var go = new GameObject(nameof(Context));
		UnityEngine.Object.DontDestroyOnLoad(go);
		FeatureFactory.RegisterAllFeatures(go);

		var commands = FeatureFactory.GetFeature<Commands>();
		if (commands == null)
			return;

		AddConsoleLog(Strings.FeatureRendererWelcome + $" ({commands.Key})");
	}
}
