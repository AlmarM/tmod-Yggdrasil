using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MagicDamageModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_magicDamageAmount * 100);
            return MakeDescription(PlayerModifierConfig.MagicDamageDescription, percentage, _magicDamageAmount);
        }
    }

    private float _magicDamageAmount;

    public MagicDamageModifier(float magicDamageAmount)
    {
        _magicDamageAmount = magicDamageAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Magic) += _magicDamageAmount;
    }
}