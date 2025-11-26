using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.YAZDHD;

internal class GetAllItems : TriggerFeature
{
	public override string Name => Strings.FeatureGetAllItemsName;
	public override string Description => Strings.FeatureGetAllItemsDescription;

	public override KeyCode Key { get; set; } = KeyCode.KeypadDivide;

	protected override void UpdateOnceWhenTriggered()
	{
		foreach (var item in Store.Get.Items)
		{
			item.available = 999999;
			item.wasPurchased = true;
			item.availableAmmo = 999999;
		}
	}
}
