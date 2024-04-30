using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace YAZDHD.Trainer
{
	public class TrainerBehaviour : MonoBehaviour
	{

		private readonly Dictionary<KeyCode, Action> _actions = new Dictionary<KeyCode, Action>();

		private FieldInfo _field;
		private bool IsPlayerImmortal
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

		void Start()
		{
			var dt = Type.GetType("DeveloperTools, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);
			_field = dt?.GetField("isPlayerImmortal", BindingFlags.Static | BindingFlags.Public);

			_actions.Clear();

			_actions.Add(KeyCode.KeypadMultiply, () =>
			{
				IsPlayerImmortal = !IsPlayerImmortal;
			});

			_actions.Add(KeyCode.KeypadDivide, () =>
			{
				foreach (var item in Store.Get.Items)
				{
					item.available = 999999;
					item.wasPurchased = true;
					item.availableAmmo = 999999;
				}
			});

			_actions.Add(KeyCode.KeypadPlus, () =>
			{
				foreach (var player in Level.Get.players)
				{
					player.numAvailableStatPoints = 999999;
				}
			});

			_actions.Add(KeyCode.KeypadMinus, () =>
			{
				Store.Get.Cash += 999999;
			});
		}

		void Update()
		{
			foreach (var keyCode in _actions.Keys)
			{
				if (Input.GetKeyDown(keyCode))
					_actions[keyCode]();
			}
		}

		void OnGUI()
		{
			var godStatus = IsPlayerImmortal ? "on" : "off";
			var display = $"Trainer loaded ! Use Keypad keys [*] God mode ({godStatus}), [/] Max all items, [+] Get stats points, [-] Get cash";
			Render.DrawString(new Vector2(764, Screen.height - 16f), display, Color.white);
		}
	}
}
