using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class ThornsModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_thornsAmount * 100);
            return MakeDescription(PlayerModifierConfig.ThornsDescription, percentage, _thornsAmount);
        }
    }

    private float _thornsAmount;

    public ThornsModifier(float thornsAmount)
    {
        _thornsAmount = thornsAmount;
    }

    public override void Apply(Player player)
    {
        player.thorns += _thornsAmount;
    }
}