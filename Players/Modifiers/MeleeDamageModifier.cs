using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MeleeDamageModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_meleeDamageAmount * 100);
            return MakeDescription(PlayerModifierConfig.MeleeDamageDescription, percentage, _meleeDamageAmount);
        }
    }

    private float _meleeDamageAmount;

    public MeleeDamageModifier(float meleeDamageAmount)
    {
        _meleeDamageAmount = meleeDamageAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Melee) += _meleeDamageAmount;
    }
}