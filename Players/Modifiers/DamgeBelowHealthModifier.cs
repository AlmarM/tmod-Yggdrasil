using System;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

internal class DamageBelowHealthModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double damagePercentage = Math.Round(_damageBonus * 100);
            double healthPercentage = Math.Round(_healthThreshold * 100);
            
            return MakeDescription(PlayerModifierConfig.DamageBelowHealthDescription, damagePercentage,
                healthPercentage);
        }
    }

    private float _damageBonus;
    private float _healthThreshold;

    public DamageBelowHealthModifier(float damageBonus, float healthThreshold)
    {
        _damageBonus = damageBonus;
        _healthThreshold = healthThreshold;
    }

    public override void Apply(Player player)
    {
        if (player.statLife >= player.statLifeMax2 * _healthThreshold)
        {
            return;
        }

        player.GetDamage(DamageClass.Magic) += _damageBonus;
        player.GetDamage(DamageClass.Melee) += _damageBonus;
        player.GetDamage(DamageClass.Ranged) += _damageBonus;
        player.GetDamage(DamageClass.Summon) += _damageBonus;
        player.GetDamage(DamageClass.Throwing) += _damageBonus;
    }
}