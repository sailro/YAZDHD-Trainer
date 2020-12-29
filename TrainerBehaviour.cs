using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace YAZDHD.Trainer
{
	public class TrainerBehaviour : MonoBehaviour
	{

		private readonly Dictionary<KeyCode, Action> _actions = new Dictionary<KeyCode, Action>();

		void Start()
		{
			_actions.Clear();

			_actions.Add(KeyCode.KeypadMultiply, () =>
			{
				var dt = Type.GetType("DeveloperTools, Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

				var field = dt?.GetField("isPlayerImmortal", BindingFlags.Static | BindingFlags.Public);
				if (field == null)
					return;

				var current = (bool)field.GetValue(null);
				current = !current;

				field.SetValue(null, current);
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
	}
}
