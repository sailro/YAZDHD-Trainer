using System;
using System.Linq;
using UnityEngine;

#nullable enable

namespace TrainerKit.Features;

internal static class FeatureFactory
{
	private static GameObject? _gameObject = null;
	private static readonly Lazy<Type[]> Types = new(() => [.. typeof(FeatureFactory)
		.Assembly
		.GetTypes()
		.Where(t => t.IsSubclassOf(typeof(Feature)) && !t.IsAbstract)]);

	public static Feature[] RegisterAllFeatures(GameObject gameObject)
	{
		_gameObject = gameObject;

		return [.. GetAllFeatureTypes()
			.Select(gameObject.AddComponent)
			.OfType<Feature>()];
	}

	public static Type[] GetAllFeatureTypes()
	{
		return Types.Value;
	}

	public static T? GetFeature<T>() where T : Feature
	{
		return GetAllFeatures()
			.OfType<T>()
			.FirstOrDefault();
	}

	public static Feature[] GetAllFeatures()
	{
		if (_gameObject == null)
			return [];

		return [.. GetAllFeatureTypes()
			.Select(_gameObject.GetComponent)
			.OfType<Feature>()];
	}

	public static ToggleFeature[] GetAllToggleableFeatures()
	{
		return [.. GetAllFeatures().OfType<ToggleFeature>()];
	}
}
