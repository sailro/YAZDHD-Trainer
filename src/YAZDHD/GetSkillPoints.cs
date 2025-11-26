using TrainerKit.Configuration;
using TrainerKit.Features;
using TrainerKit.Properties;
using UnityEngine;

namespace TrainerKit.YAZDHD;

internal class GetSkillPoints : TriggerFeature
{
	public override string Name => Strings.FeatureGetSkillPointsName;
	public override string Description => Strings.FeatureGetSkillPointsDescription;

	public override KeyCode Key { get; set; } = KeyCode.KeypadPlus;

	[ConfigurationProperty]
	public int Amount { get; set; } = 999999;

	protected override void UpdateOnceWhenTriggered()
	{
		foreach (var player in Level.Get.players)
		{
			player.numAvailableStatPoints = Amount;
		}
	}
}
