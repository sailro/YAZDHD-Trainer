using UnityEngine;

#nullable enable

namespace TrainerKit.Extensions;

public static class StringExtensions
{
	extension(string str)
	{
		public string Color(Color color)
		{
			return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{str}</color>";
		}

		public string Blue()
		{
			return str.Color(UnityEngine.Color.blue);
		}

		public string Yellow()
		{
			return str.Color(UnityEngine.Color.yellow);
		}

		public string Red()
		{
			return str.Color(UnityEngine.Color.red);
		}

		public string Green()
		{
			return str.Color(UnityEngine.Color.green);
		}

		public string Cyan()
		{
			return str.Color(UnityEngine.Color.cyan);
		}
	}
}
