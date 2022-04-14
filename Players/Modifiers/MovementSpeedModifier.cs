using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MovementSpeedModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_movementSpeedAmount * 100);
            return MakeDescription(PlayerModifierConfig.MovementSpeedDescription, percentage, _movementSpeedAmount);
        }
    }

    private float _movementSpeedAmount;

    public MovementSpeedModifier(float movementSpeedAmount)
    {
        _movementSpeedAmount = movementSpeedAmount;
    }

    public override void Apply(Player player)
    {
        player.moveSpeed += _movementSpeedAmount;

    }
}