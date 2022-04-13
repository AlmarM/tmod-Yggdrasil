using System;
using Terraria;
using Yggdrasil.Configs;
using Terraria.ModLoader;

namespace Yggdrasil.Players.Modifiers;

public class MaxRunSpeedModifier : PlayerModifier
{
    public override string Description
    {
        get
        {
            double percentage = Math.Round(_maxRunSpeedAmount * 100);
            return MakeDescription(PlayerModifierConfig.MaxRunSpeedDescription, percentage, _maxRunSpeedAmount);
        }
    }  

    private float _maxRunSpeedAmount;

    public MaxRunSpeedModifier(float maxRunSpeedAmount)
    {
        _maxRunSpeedAmount = maxRunSpeedAmount;
    }

    public override void Apply(Player player)
    {
        player.maxRunSpeed += _maxRunSpeedAmount;

    }
}