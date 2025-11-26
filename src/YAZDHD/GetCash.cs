using TrainerKit.Configuration;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.YAZDHD;

internal class GetCash : TriggerFeature
{
	public override string Name => Strings.FeatureGetCashName;
	public override string Description => Strings.FeatureGetCashDescription;

	public override KeyCode Key { get; set; } = KeyCode.KeypadMinus;

	[ConfigurationProperty]
	public int Amount { get; set; } = 999999;

	protected override void UpdateOnceWhenTriggered()
	{
		Store.Get.Cash += Amount;
	}
}
