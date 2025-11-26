using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TrainerKit.Configuration;
using UnityEngine;

#nullable enable

namespace TrainerKit.Features;

internal abstract class CachableFeature<T> : ToggleFeature
{
	[ConfigurationProperty(Order = 3)]
	public abstract float CacheTimeInSec { get; set; }

	private readonly List<T> _data = [];
	private bool _refreshing = false;

	[UsedImplicitly]
	private void Start()
	{
		StartCoroutine(RefreshDataScheduler());
	}

	private IEnumerator RefreshDataScheduler()
	{
		if (Enabled)
		{
			try
			{
				_refreshing = true;

				BeforeRefreshData(_data);
				_data.Clear(); // but we'll keep previous capacity
				RefreshData(_data);
			}
			finally
			{
				_refreshing = false;
			}
		}

		yield return new WaitForSeconds(CacheTimeInSec);
		StartCoroutine(RefreshDataScheduler());
	}

	protected override void UpdateWhenEnabled()
	{
		if (_refreshing)
			return;

		if (_data.Count > 0)
			ProcessData(_data);
	}

	protected override void OnGUIWhenEnabled()
	{
		if (_refreshing)
			return;

		if (_data.Count > 0)
			ProcessDataOnGUI(_data);
	}

	protected virtual void BeforeRefreshData(IReadOnlyList<T> data) { }
	public abstract void RefreshData(List<T> data);
	public virtual void ProcessData(IReadOnlyList<T> data) { }
	public virtual void ProcessDataOnGUI(IReadOnlyList<T> data) { }
}
