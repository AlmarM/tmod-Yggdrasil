using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MaximumRunSpeedModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_maximumRunSpeedAmount * 100);
            return MakeDescription(PlayerModifierConfig.MaximumRunSpeedDescription, percentage, _maximumRunSpeedAmount);
        }
    }  

    private float _maximumRunSpeedAmount;

    public MaximumRunSpeedModifier(float maximumRunSpeedAmount)
    {
        _maximumRunSpeedAmount = maximumRunSpeedAmount;
    }

    public override void Apply(Player player)
    {
        player.maxRunSpeed += _maximumRunSpeedAmount;

    }
}