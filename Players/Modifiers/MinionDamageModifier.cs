using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MinionDamageModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_minionDamageAmount * 100);
            return MakeDescription(PlayerModifierConfig.MinionDamageDescription, percentage, _minionDamageAmount);
        }
    }

    private float _minionDamageAmount;

    public MinionDamageModifier(float minionDamageAmount)
    {
        _minionDamageAmount = minionDamageAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Summon) += _minionDamageAmount;
    }
}