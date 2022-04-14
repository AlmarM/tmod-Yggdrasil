using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class DamageReductionModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_damageReduction * 100);
            return MakeDescription(PlayerModifierConfig.DamageReductionDescription, percentage, _damageReduction);
        }
    }

    private float _damageReduction;

    public DamageReductionModifier(float damageReduction)
    {
        _damageReduction = damageReduction;
    }

    public override void Apply(Player player)
    {
        player.endurance += _damageReduction;
    }
}