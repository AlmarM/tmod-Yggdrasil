using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class ThrowingDamageModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_throwingDamageAmount * 100);
            return MakeDescription(PlayerModifierConfig.ThrowingDamageDescription, percentage, _throwingDamageAmount);
        }
    }

    private float _throwingDamageAmount;

    public ThrowingDamageModifier(float throwingDamageAmount)
    {
        _throwingDamageAmount = throwingDamageAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Throwing) += _throwingDamageAmount;
    }
}