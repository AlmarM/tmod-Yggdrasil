using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class CriticalChanceModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.CriticalChanceDescription, _criticalChanceMeleeAmount); //using melee as all crits will be the same
	
	private int _criticalChanceMeleeAmount;
	private int _criticalChanceRangedAmount;
	private int _criticalChanceMagicAmount;
	private int _criticalChanceThrowingAmount;
	//private int _criticalChanceRunicAmount;

    public CriticalChanceModifier(int criticalChanceMeleeAmount, int criticalChanceRangedAmount, int criticalChanceMagicAmount, int criticalChanceThrowingAmount) 
    {
        _criticalChanceMeleeAmount = criticalChanceMeleeAmount;
		_criticalChanceRangedAmount = criticalChanceRangedAmount;
		_criticalChanceMagicAmount = criticalChanceMagicAmount;
		_criticalChanceThrowingAmount = criticalChanceThrowingAmount;
    }

    public override void Apply(Player player)
    {
		player.GetCritChance(DamageClass.Melee) += _criticalChanceMeleeAmount;
		player.GetCritChance(DamageClass.Ranged) += _criticalChanceRangedAmount;
		player.GetCritChance(DamageClass.Magic) += _criticalChanceMagicAmount;
		player.GetCritChance(DamageClass.Throwing) += _criticalChanceThrowingAmount;
    }
}