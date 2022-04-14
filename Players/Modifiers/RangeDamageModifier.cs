using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class RangeDamageModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_rangeDamageAmount * 100);
            return MakeDescription(PlayerModifierConfig.RangeDamageDescription, percentage, _rangeDamageAmount);
        }
    }

    private float _rangeDamageAmount;

    public RangeDamageModifier(float rangeDamageAmount)
    {
        _rangeDamageAmount = rangeDamageAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += _rangeDamageAmount;
    }
}