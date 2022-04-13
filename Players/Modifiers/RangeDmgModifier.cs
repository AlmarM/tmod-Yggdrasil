using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class RangeDmgModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_rangeDmgAmount * 100);
            return MakeDescription(PlayerModifierConfig.RangeDmgDescription, percentage, _rangeDmgAmount);
        }
    }

    private float _rangeDmgAmount;

    public RangeDmgModifier(float rangeDmgAmount)
    {
        _rangeDmgAmount = rangeDmgAmount;
    }

    public override void Apply(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += _rangeDmgAmount;
    }
}