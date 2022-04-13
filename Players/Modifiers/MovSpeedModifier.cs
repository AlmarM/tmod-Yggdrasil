using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MovSpeedModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_movSpeedAmount * 100);
            return MakeDescription(PlayerModifierConfig.MovSpeedDescription, percentage, _movSpeedAmount);
        }
    }

    private float _movSpeedAmount;

    public MovSpeedModifier(float movSpeedAmount)
    {
        _movSpeedAmount = movSpeedAmount;
    }

    public override void Apply(Player player)
    {
        player.moveSpeed += _movSpeedAmount;

    }
}