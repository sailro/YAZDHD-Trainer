using System;
using System.Reflection;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.YAZDHD
{
	internal class GodMode : ToggleFeature
	{
		public override string Name => Strings.FeatureGodModeName;
		public override string Description => Strings.FeatureGodModeDescription;

		public override KeyCode Key { get; set; } = KeyCode.KeypadMultiply;

		protected override void UpdateWhenEnabled()
		{
			IsPlayerImmortal = true;
		}

		protected override void UpdateWhenDisabled()
		{
			IsPlayerImmortal = false;
		}

		private static readonly FieldInfo _field;
		private static bool IsPlayerImmortal
		{
			get
			{
				return _field != null && (bool)_field.GetValue(null);
			}
			set
			{
				if (_field == null)
					return;

				_field.SetValue(null, value);
			}

		}

		static GodMode()
		{
			var dt = Type.GetType("DeveloperTools, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);
			_field = dt?.GetField("isPlayerImmortal", BindingFlags.Static | BindingFlags.Public);
		}
	}
}
